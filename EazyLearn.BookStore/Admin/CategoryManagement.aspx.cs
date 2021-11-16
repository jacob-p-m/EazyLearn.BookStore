using EazyLearn.BookStore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EazyLearn.BookStore.Admin_Pages
{
    public partial class CategoryManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fill();

            }


        }

        protected void gvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Fill()
        {
            Category objCategory = new Category();

            gvCategory.DataSource = objCategory.GetAllCategoryDetails();
            gvCategory.DataBind();
        }

        protected void gvCategory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCategory.EditIndex = e.NewEditIndex;
            Fill();
            int index = gvCategory.EditIndex;
            GridViewRow row = gvCategory.Rows[index];
            string categoryName = ((TextBox)row.FindControl("txtCategoryName")).Text;
            string strCategoryId = ((Label)row.FindControl("lblCategoryId")).Text;
            int categoryId = Convert.ToInt32(strCategoryId);

            Category objCategory = new Category();
            objCategory.Name = categoryName;
            objCategory.UpdateCategoryDetails(categoryId);

        }

        protected void gvCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


        }

        protected void gvCategory_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void gvCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {

                int categoryId = Convert.ToInt32(e.CommandArgument);

                Category objCategory = new Category();
                objCategory.DeleteCategoryDetails(categoryId);
                Fill();
            }
            else if (e.CommandName == "Update")
            {
                int index = gvCategory.EditIndex;
                GridViewRow row = gvCategory.Rows[index];
                int categoryId = Convert.ToInt32(e.CommandArgument);

                Category objCategory = new Category();
                string categoryName = ((TextBox)row.FindControl("txtCategoryName")).Text;
                objCategory.Name = categoryName;

                objCategory.UpdateCategoryDetails(categoryId);
                gvCategory.EditIndex = -1;
                Fill();
            }


        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {


        }

        protected void gvCategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCategory.EditIndex = -1;
            Fill();
        }

        protected void btnInsert_Click1(object sender, EventArgs e)
        {
            string categoryName = txtInsert.Text.ToString();
            Category objCategory = new Category();
            objCategory.Name = categoryName;
            objCategory.InsertCategoryDetails();
            Fill();
            txtInsert.Text = "";
        }

        protected void gvCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Fill();
            gvCategory.PageIndex = e.NewPageIndex;
            gvCategory.DataBind();
        }
    }
}
