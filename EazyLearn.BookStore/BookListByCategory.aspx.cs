using EazyLearn.BookStore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EazyLearn.BookStore
{
    public partial class BookListByCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(Request.QueryString["categoryId"].ToString());
            

            if (!IsPostBack)
            {
                Book objBook = new Book();

                gvBookListByCategoryId.DataSource = objBook.GetAllBookDetailsGivenCategoryId(categoryId);
                gvBookListByCategoryId.DataBind();
            }
        }

        protected void gvBookListByCategoryId_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSpecialPrice = (Label)e.Row.FindControl("lblSpecialPrice");
                if (lblSpecialPrice.Text == "0.00")
                {
                    lblSpecialPrice.Text = "";
                }
            }
        }
    }
}