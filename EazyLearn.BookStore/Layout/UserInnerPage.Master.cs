using EazyLearn.BookStore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EazyLearn.BookStore.Layout
{
    public partial class UserInnerPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Category objCategory = new Category();

            gvCategoryList.DataSource = objCategory.GetAllCategoryDetails();
            gvCategoryList.DataBind();

            if (Session["UserEmail"] != null)
            {
                lblUserEmailStatus.Text = Session["UserEmail"].ToString();
            }

            btnUserLogout.ServerClick += new EventHandler(ButtonLogout_Click);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }

        protected void gvCategoryList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}
