using EazyLearn.BookStore.Components;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace EazyLearn.BookStore
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        double billAmount;
        double shippingCharge;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fill();            
            }
        }

        void Fill()
        {
            string userEmail = Session["UserEmail"].ToString();

            Cart objCart = new Cart();
            Order objOrder = new Order();
            DataTable dt = objOrder.GetOrderDetailsGivenUserEmail(userEmail);

            if (dt!=null && dt.Rows.Count > 0)
            {
                int orderId = Convert.ToInt32(objOrder.GetOrderDetailsGivenUserEmail(userEmail).Rows[0]["Order Id"]);

                
                ////if cart is empty return
                //DataTable dtCart = objCart.GetCartDetailsGivenOrderId(orderId);
                //if (dtCart == null || dtCart.Rows.Count <= 0)
                //{
                //    return;
                //}
                //show order id
                lblOrderId.Text = orderId.ToString();
                gvCart.DataSource = objCart.GetCartDetailsGivenOrderId(orderId);
                gvCart.DataBind();

                if (gvCart.Rows.Count > 0)
                {
                    //get shipping charge percent
                    shippingCharge = Convert.ToDouble(ConfigurationManager.AppSettings["shippingCharge"]);

                    //show shipping charges
                    (gvCart.FooterRow.FindControl("txtShippingAmount") as TextBox).Text = shippingCharge.ToString();
                    
                    //calculate bill amount
                    billAmount = Convert.ToDouble(objCart.CalculateBillAmountCart(orderId).Rows[0].ItemArray[0]);
                    //add shipping charges
                    billAmount += shippingCharge;
                    //update bill amount
                    objCart.UpdateCartBill(orderId, billAmount);
                    //show bill amount
                    (gvCart.FooterRow.FindControl("txtBillAmount") as TextBox).Text = billAmount.ToString() ;
                    
             
                }
            }
            else
            {
                ////delete order details
                //int orderId = Convert.ToInt32(objOrder.GetOrderDetailsGivenUserEmail(userEmail).Rows[0]["Order Id"]);
                //objOrder.DeleteOrderDetails(orderId);

                //creating new order number for the user
                //objOrder.UserEmail = userEmail;
                //objOrder.InsertOrderDetails();
            }
        }

        protected void gvCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Fill quantity drop-down list
            List<int> quantityList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSpecialPrice = (Label)e.Row.FindControl("lblSpecialPrice");
                if (lblSpecialPrice.Text == "0.00")
                {
                    lblSpecialPrice.Text = "";
                }

                DropDownList ddlQuantity = (DropDownList)e.Row.FindControl("ddlQuantity");
                ddlQuantity.DataSource = quantityList;
                GridViewRow row = ((GridViewRow)ddlQuantity.Parent.Parent);
                Label lblBookId = (Label)row.FindControl("lblBookId");

                int bookid = Convert.ToInt32(lblBookId.Text.ToString());
                string userEmail = Session["UserEmail"].ToString();

                Cart objCart = new Cart();
                Order objOrder = new Order();
                int orderId = Convert.ToInt32(objOrder.GetOrderDetailsGivenUserEmail(userEmail).Rows[0]["Order Id"]);

                DataTable dt = objCart.GetCartDetailsGivenOrderIdAndBookId(orderId, bookid);
                int quantity = Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());
                ddlQuantity.SelectedValue = quantity.ToString();
                ddlQuantity.DataBind();
            }
        }

        protected void gvCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlQuantity = (DropDownList)sender;
            GridViewRow row = ((GridViewRow)ddlQuantity.Parent.Parent);
            Label lblBookId = (Label)row.FindControl("lblBookId");

            int bookid = Convert.ToInt32(lblBookId.Text.ToString());
            string userEmail = Session["UserEmail"].ToString();
            int quantity = Convert.ToInt32(ddlQuantity.SelectedValue);

            Cart objCart = new Cart();
            Order objOrder = new Order();
            int orderId = Convert.ToInt32(objOrder.GetOrderDetailsGivenUserEmail(userEmail).Rows[0]["Order Id"]);

            objCart.BookId = bookid;
            objCart.OrderId = orderId;
            objCart.Quantity = quantity;
            objCart.UpdateCartDetails();
            Fill();
        }

        protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            
        }

        protected void gvCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int bookId = Convert.ToInt32(e.CommandArgument);
                string userEmail = Session["UserEmail"].ToString();

                Cart objCart = new Cart();
                Order objOrder = new Order();
                int orderId = Convert.ToInt32(objOrder.GetOrderDetailsGivenUserEmail(userEmail).Rows[0]["Order Id"]);

                objCart.DeleteCartDetails(orderId, bookId);

                Fill();
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            string userEmail = Session["UserEmail"].ToString();
            Order objOrder = new Order();
            int orderId = Convert.ToInt32(objOrder.GetOrderDetailsGivenUserEmail(userEmail).Rows[0]["Order Id"]);
            
            //update order table
            objOrder.UserEmail = userEmail;

            DateTime currentDate = DateTime.Now;


            objOrder.OrderDate = currentDate; 
            objOrder.OrderId = orderId;

            Cart objCart = new Cart();
            billAmount = Convert.ToDouble(objCart.GetCartDetailsGivenOrderId(orderId).Rows[0]["Bill Amount"]);
            objOrder.Amount = billAmount;
            objOrder.UpdateOrderDetails();

          


            Response.Redirect("~/PaymentDetails.aspx");

        }
    }
}