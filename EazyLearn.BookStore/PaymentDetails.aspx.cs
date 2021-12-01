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
            ddlMonth.DataSource = monthList;
            ddlMonth.DataBind();
            ddlYear.DataSource = yearList;
            ddlYear.DataBind();

            //show order id 
            string userEmail = Session["UserEmail"].ToString();
            Order objOrder = new Order();
            int orderId = Convert.ToInt32(objOrder.GetOrderDetailsGivenUserEmail(userEmail).Rows[0]["Order Id"]);
            lblOrderId.Text = orderId.ToString();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string month, year, number,cvv;
            bool cardValid;


            cvv = txtCvv.Text.ToString();
            month = ddlMonth.SelectedValue;
            year = ddlYear.SelectedValue;
            number = txtCardNumber.Text.ToString();

            //calling credit card validation web service
            CreditCardValidationWebService.CreditCardValidationSoapClient client = new CreditCardValidationWebService.CreditCardValidationSoapClient();
            cardValid = client.ValidateCreditCard(number, month, year, cvv);

            if (cardValid)
            {
                WriteOrderIntoOrderDetailsTable();
                Response.Redirect("~/OrderConfirmation.aspx");
            }
            else
            {
                lblValidation.Text = "Card Not Valid";
                return;
            }
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