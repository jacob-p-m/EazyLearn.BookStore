using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EazyLearn.BookStore.Admin_Pages
{
    public partial class AdminDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Context.Items["Username"].ToString();
            welcomemessage.Text = $"Welcome {username}";

            Label lblUserHeader = (Label)Master.FindControl("UserHeaderName");
            lblUserHeader.Text = username;
        }
    }
}
