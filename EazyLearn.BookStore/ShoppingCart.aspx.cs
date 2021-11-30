using EazyLearn.BookStore.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EazyLearn.BookStore
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        double billAmount;

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

                //if cart is empty return
                DataTable dtCart = objCart.GetCartDetailsGivenOrderId(orderId);
                if (dtCart == null || dtCart.Rows.Count <= 0)
                {
                    return;
                }
                //show order id
                lblOrderId.Text = orderId.ToString();
                gvCart.DataSource = objCart.GetCartDetailsGivenOrderId(orderId);
                gvCart.DataBind();

                if (gvCart.Rows.Count > 0)
                {
                    //show bill amount
                    (gvCart.FooterRow.FindControl("txtBillAmount") as TextBox).Text = objCart.GetBillAmountCart(orderId).Rows[0].ItemArray[0].ToString() ?? "0";
                    billAmount = Convert.ToDouble((gvCart.FooterRow.FindControl("txtBillAmount") as TextBox).Text);
                }
            }
            else
            {
                ////delete order details
                //int orderId = Convert.ToInt32(objOrder.GetOrderDetailsGivenUserEmail(userEmail).Rows[0]["Order Id"]);
                //objOrder.DeleteOrderDetails(orderId);

                //creating new order number for the user
                objOrder.UserEmail = userEmail;
                objOrder.InsertOrderDetails();
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
            billAmount = Convert.ToDouble((gvCart.FooterRow.FindControl("txtBillAmount") as TextBox).Text);

            objOrder.Amount = billAmount;
            objOrder.UpdateOrderDetails();

            //check whether the order already exists in the order details table
            OrderDetails objOdd = new OrderDetails();
            DataTable dt = objOdd.GetOrderDetailsGivenOrderId(orderId);
            Cart objCart = new Cart();

            if (dt== null || dt.Rows.Count <= 0)
            {

                //need to insert the cart details into order details table
                DataTable dtCart = objCart.GetCartDetailsGivenOrderId(orderId);
                if (dtCart==null || dtCart.Rows.Count <= 0)
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
                    objOdd.BillAmount = Convert.ToDouble(billAmount);
                    objOdd.InsertOrderDetails();
                }
            }

            objCart.DeleteCartDetailsByOrderId(orderId);


            Response.Redirect("~/OrderItems.aspx");

        }
    }
}