using EazyLearn.BookStore.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EazyLearn.BookStore.Admin
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
            DataTable dtAdmin = null;
            string username = Master.Username;
            string password = Master.Password;
            string realPassword;

            if (username == "")
            {
                lblValidationMessage.Text = "*Enter username";
            }
            else if (password == "")
            {
                lblValidationMessage.Text = "*Enter password";
            }
            else
            {
                Administrator objAdmin = new Administrator();
                objAdmin.Username = username;
                dtAdmin = objAdmin.GetAdminPassword();
                if (dtAdmin.Rows.Count > 0)
                {
                    realPassword = dtAdmin.Rows[0].ItemArray[0].ToString();
                    if (realPassword == password)
                    {
                        Context.Items["Username"] = username;
                        Server.Transfer("~/Admin/Home.aspx");
                    }
                    else
                    {
                        lblValidationMessage.Text = "*Wrong Password";
                    }
                }
                else
                {
                    lblValidationMessage.Text = "*Invalid username";
                }
            }

        }


    }

}
