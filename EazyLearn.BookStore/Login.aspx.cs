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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.LoginButton.Click += new EventHandler(SearchButton_Click);


        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            //code when login button click goes here
            DataTable dt = null;
            string username = Master.Username;
            string password = Master.Password;
            string realPassword;

            if (username == "")
            {
                lblValidationMessage.Text = "*Enter email id";
            }
            else if (password == "")
            {
                lblValidationMessage.Text = "*Enter password";
            }
            else
            {
                Customer objUser = new Customer();
                objUser.Email = username;
                dt = objUser.GetUserPassword();
                if (dt.Rows.Count > 0)
                {
                    realPassword = dt.Rows[0].ItemArray[0].ToString();
                    if (realPassword == password)
                    {
                        Session["UserEmail"] = username.ToString();
                        Response.Redirect("~/Home.aspx");
                    }
                    else
                    {
                        lblValidationMessage.Text = "*Wrong Password";
                    }
                }
                else
                {
                    lblValidationMessage.Text = "*Invalid email id";
                }
            }

        }

        protected void lblAdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Login.aspx");
        }
    }
}
