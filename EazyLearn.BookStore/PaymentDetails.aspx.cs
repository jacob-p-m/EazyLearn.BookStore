using EazyLearn.BookStore.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EazyLearn.BookStore
{
    public partial class PaymentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fill();    
            }
        }

        void Fill()
        {
            //populating year and month drop down lists
            List<string> monthList = new List<string> { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
            List<string> yearList = new List<string> { "21", "22", "23", "24", "25", "26" };
            List<string> cardTypeList = new List<string> { "Master", "Visa", "RuPay" };
            ddlMonth.DataSource = monthList;
            ddlMonth.DataBind();
            ddlYear.DataSource = yearList;
            ddlYear.DataBind();
            ddlCardType.DataSource = cardTypeList;
            ddlCardType.DataBind();

            //show order id 
            string userEmail = Session["UserEmail"].ToString();
            Order objOrder = new Order();
            int orderId = Convert.ToInt32(objOrder.GetOrderDetailsGivenUserEmail(userEmail).Rows[0]["Order Id"]);
            lblOrderId.Text = orderId.ToString();

            double billAmount = Convert.ToDouble(objOrder.GetOrderDetailsGivenUserEmail(userEmail).Rows[0]["Bill Amount"]);
            lblOrderTotal.Text = billAmount.ToString();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string cardType, month, year, number,cvv;
            bool cardValid;


            cvv = txtCvv.Text.ToString();
            month = ddlMonth.SelectedValue;
            year = ddlYear.SelectedValue;
            number = txtCardNumber.Text.ToString();
            cardType = ddlCardType.SelectedValue;

            //calling credit card validation web service
            CreditCardValidationWebService.CreditCardValidationSoapClient client = new CreditCardValidationWebService.CreditCardValidationSoapClient();
            cardValid = client.ValidateCreditCard(cardType, number, month, year, cvv);

            if (cardValid)
            {
                WriteOrderIntoOrderDetailsTable();

                if (!CheckCardAlreadyExists(number))
                {
                    InsertPaymentDetails(cardType, number, month, year);
                }
                Response.Redirect("~/OrderConfirmation.aspx");
            }
            else
            {
                lblValidation.Text = "Card Not Valid";
                return;
            }
        }


        bool CheckCardAlreadyExists(string cardnumber)
        {
            string userEmail = Session["UserEmail"].ToString();
            Payment objPayment = new Payment();
            DataTable dtCard = objPayment.GetCardNumberGivenUserEmail(userEmail);

            foreach (DataRow row in dtCard.Rows)
            {
                if (row["Card Number"].ToString() == cardnumber.ToString())
                {
                    return true;
                }
            }
            return false;

        }


        void InsertPaymentDetails(string cardtype, string cardnumber, string month, string year)
        {
            //insert payment details of a customer into the database
            string userEmail = Session["UserEmail"].ToString();
            Payment objPayment = new Payment();
            objPayment.UserEmail = userEmail;
            objPayment.CreditCardNumber = cardnumber;
            objPayment.CreditCardType = cardtype;
            objPayment.Month = month;
            objPayment.Year = year;
            objPayment.InsertPaymentDetails();
        }

        void WriteOrderIntoOrderDetailsTable()
        {
            Order objOrder = new Order();
            string userEmail = Session["UserEmail"].ToString();

            int orderId = Convert.ToInt32(objOrder.GetOrderDetailsGivenUserEmail(userEmail).Rows[0]["Order Id"]);

            //check whether the order already exists in the order details table
            OrderDetails objOdd = new OrderDetails();
            DataTable dt = objOdd.GetOrderDetailsGivenOrderId(orderId);
            Cart objCart = new Cart();

            if (dt == null || dt.Rows.Count <= 0)
            {

                //need to insert the cart details into order details table
                DataTable dtCart = objCart.GetCartDetailsGivenOrderId(orderId);
                if (dtCart == null || dtCart.Rows.Count <= 0)
                {
                    return;
                }

                //getting data from the cart table for a given orderid and inserting it into order details table.
                foreach (DataRow row in dtCart.Rows)
                {
                    objOdd.OrderId = Convert.ToInt32(orderId);
                    objOdd.BookId = Convert.ToInt32(row["Book Id"]);
                    objOdd.Quantity = Convert.ToInt32(row["Quantity"]);
                    objOdd.UnitPrice = Convert.ToDouble(row["Unit Price"]);
                    objOdd.TotalAmount = Convert.ToDouble(row["Total Amount"]);
                    objOdd.BillAmount = Convert.ToDouble(objOrder.GetOrderDetailsGivenUserEmail(userEmail).Rows[0]["Bill Amount"]);
                    objOdd.InsertOrderDetails();
                }
            }

            objCart.DeleteCartDetailsByOrderId(orderId);

        }


    }

  
}