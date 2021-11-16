using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EazyLearn.BookStore.Layout
{
    public partial class LoginMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string Username
        {
            get
            {
                return txtUsername.Value;
            }
            set
            {
                txtUsername.Value = value;
            }
        }

        public string Password
        {
            get
            {
                return txtPassword.Value;
            }
            set
            {
                txtPassword.Value = value;
            }
        }

        public Button LoginButton
        {
            get
            {
                return this.btnLogin;
            }
        }

    }
}
