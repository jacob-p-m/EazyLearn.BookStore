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
    public partial class OrderItems : System.Web.UI.Page
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
            string userEmail = Session["UserEmail"].ToString();
            Order objOrder = new Order();
            int orderId = Convert.ToInt32(objOrder.GetOrderDetailsGivenUserEmail(userEmail).Rows[0]["Order Id"]);
            OrderDetails objOdd = new OrderDetails();
            DataTable dtOrderDetails = objOdd.GetOrderDetailsGivenOrderId(orderId);
            double billAmount = Convert.ToDouble(dtOrderDetails.Rows[0]["Bill Amount"]);
            gvOrderDetails.DataSource = dtOrderDetails;
            gvOrderDetails.DataBind();

            if (gvOrderDetails.Rows.Count > 0)
            {
                //show bill amount
                (gvOrderDetails.FooterRow.FindControl("txtBillAmount") as TextBox).Text = billAmount.ToString();
            }
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PaymentDetails.aspx");
        }
    }
}