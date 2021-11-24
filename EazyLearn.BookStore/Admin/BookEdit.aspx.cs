using EazyLearn.BookStore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EazyLearn.BookStore.Admin
{
    public partial class BookEdit : System.Web.UI.Page
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
            Book objBook = new Book();
            gvBookList.DataSource = objBook.GetAllBookDetails();
            gvBookList.DataBind();
        }


        protected void gvBookList_RowEditing1(object sender, GridViewEditEventArgs e)
        {

            int bookId = Convert.ToInt32(gvBookList.Rows[e.NewEditIndex].Cells[0].Text);
            Response.Redirect("~/Admin/BookDetailsEdit.aspx?bookId=" + bookId);
        }

        protected void gvBookList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Fill();
            gvBookList.PageIndex = e.NewPageIndex;
            gvBookList.DataBind();
        }

        protected void gvBookList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvBookList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int bookId = Convert.ToInt32(gvBookList.Rows[e.RowIndex].Cells[0].Text);
            Book objBook = new Book();
            objBook.DeleteBook(bookId);
            Fill();
        }
    }
}
