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
    public partial class OrderConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Fill();

            Order objOrder = new Order();
            string userEmail = Session["UserEmail"].ToString();
            int orderId = Convert.ToInt32(objOrder.GetOrderDetailsGivenUserEmail(userEmail).Rows[0]["Order Id"]);

            //delete order details
            objOrder.DeleteOrderDetails(orderId);

            //creating new order number for the user
            objOrder.UserEmail = userEmail;
            objOrder.InsertOrderDetails();

            //Send Mail 
            //SendEmail(orderString, userEmail);
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

        //Function to send email
        public static void SendEmail(string emailBody, string userEmail)
        {
            MailMessage mailMessage = new MailMessage("EazyLearn@gmail.com", userEmail);
            mailMessage.Subject = "Order Confirmation and Details";
            mailMessage.Body = userEmail;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential()
            {
                UserName = "EazyLearn@gmail.com",
                Password = "1234"
            };

            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }
    }
}