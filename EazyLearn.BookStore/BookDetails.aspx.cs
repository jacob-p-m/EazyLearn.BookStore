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
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int bookId;

            bookId = Convert.ToInt32(Request.QueryString["bookId"].ToString());

            if (!IsPostBack)
            {
                Book objBook = new Book();
                DataTable dtBook = new DataTable();
            
                dtBook = objBook.GetAllBookDetailsById(bookId);
                lblBookId.Text = dtBook.Rows[0]["Book Id"].ToString();
                lblBookName.Text = dtBook.Rows[0]["Book Title"].ToString();
                lblBookPrice.Text = dtBook.Rows[0]["Book Price"].ToString();

                if (dtBook.Rows[0]["Special Price Status"].ToString() == "1")
                {
                    lblBookSpecialPrice.Text = dtBook.Rows[0]["Book Special Price"].ToString();
                }

                lblBookDescription.Text = dtBook.Rows[0]["Book Description"].ToString();
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            int bookId;
            bookId = Convert.ToInt32(Request.QueryString["bookId"].ToString());
            string userEmail = Session["UserEmail"].ToString();

            //Adding the book to the cart
            //code here...........

            Book objBook = new Book();
            Cart objCart = new Cart();
            DataTable dtBook = new DataTable();

            //Check if book already exists in cart
            dtBook = objCart.GetCartDetailsGivenUserEmailAndBookId(userEmail, bookId);
            if (dtBook.Rows.Count > 0)
            {
                lblShowMessage.Text = "Book already exists in cart";
                return;
            }

            dtBook = objBook.GetAllBookDetailsById(bookId);
            objCart.UserEmail = userEmail;
            objCart.BookId = Convert.ToInt32(dtBook.Rows[0]["Book Id"]);
            objCart.Quantity = 1;
            objCart.UnitPrice = Convert.ToInt32(dtBook.Rows[0]["Book Price"]);
            objCart.InsertCartDetails();

            Response.Redirect("~/ShoppingCart.aspx");
        }
    }
}