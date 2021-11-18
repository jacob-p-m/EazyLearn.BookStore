using EazyLearn.BookStore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EazyLearn.BookStore
{
    public partial class Store : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Category objCategory = new Category();

            gvCategoryList.DataSource = objCategory.GetAllCategoryDetails();
            gvCategoryList.DataBind();

            if (Session["AdminName"] != null)
            {
                lblAdminNameStatus.Text = Session["AdminName"].ToString();
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

            btnAdminLogout.ServerClick += new EventHandler(LogoutButton_Click);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }

    }
}
