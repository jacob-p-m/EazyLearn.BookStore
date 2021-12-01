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
        bool bookAdded = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            int bookId;

            bookId = Convert.ToInt32(Request.QueryString["bookId"].ToString());
            string userEmail = Session["UserEmail"].ToString();

            Book objBook = new Book();
            Cart objCart = new Cart();
            DataTable dtBook = new DataTable();


            //Check if book already exists in cart
            Order objOrder = new Order();
            //check if order exists for a specific user email

            DataTable dt = objOrder.GetOrderDetailsGivenUserEmail(userEmail);

            if (dt != null && dt.Rows.Count > 0)
            {
                int orderId = Convert.ToInt32(objOrder.GetOrderDetailsGivenUserEmail(userEmail).Rows[0]["Order Id"]);
                dtBook = objCart.GetCartDetailsGivenOrderIdAndBookId(orderId, bookId);

                if (dtBook.Rows.Count > 0)
                {
                    btnAddToCart.Text = "Item Added";
                    btnAddToCart.BackColor = System.Drawing.Color.Red;
                    btnAddToCart.ForeColor = System.Drawing.Color.White;
                    bookAdded = true;
                }
            }
            imgBook.Style.Add("display", "inline");
            imgBook.Style.Add("float", "left");

            if (!IsPostBack)
            {
                Fill();
            }
        }

        void Fill()
        {
            int bookId;
            Book objBook = new Book();
            DataTable dtBook = new DataTable();

            bookId = Convert.ToInt32(Request.QueryString["bookId"].ToString());
            dtBook = objBook.GetAllBookDetailsById(bookId);
            lblBookId.Text = dtBook.Rows[0]["Book Id"].ToString();
            imgBook.ImageUrl = dtBook.Rows[0]["Book Image Url"].ToString();
            lblBookName.Text = dtBook.Rows[0]["Book Title"].ToString();
            lblBookPrice.Text = dtBook.Rows[0]["Book Price"].ToString();

            if (Convert.ToInt32(dtBook.Rows[0]["Special Price Status"]) == 1)
            {
                lblBookSpecialPrice.Text = dtBook.Rows[0]["Book Special Price"].ToString();
            }
            else
            {
                lblBookSpecialPrice.Text = "No Special Price for this book now";
            }

            lblBookDescription.Text = dtBook.Rows[0]["Book Description"].ToString();
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (bookAdded)
            {
                return;
            }

            int bookId;
            bookId = Convert.ToInt32(Request.QueryString["bookId"].ToString());
            string userEmail = Session["UserEmail"].ToString();

            //Adding the book to the cart
            //code here...........

            Book objBook = new Book();
            Cart objCart = new Cart();
            DataTable dtBook = new DataTable();

            Order objOrder = new Order();
            //objOrder.UserEmail = userEmail;
            //objOrder.InsertOrderDetails(); 
            //getting new order number
            int orderId = Convert.ToInt32(objOrder.GetOrderDetailsGivenUserEmail(userEmail).Rows[0]["Order Id"]);
            

            dtBook = objBook.GetAllBookDetailsById(bookId);
            objCart.OrderId = orderId;
            objCart.BookId = Convert.ToInt32(dtBook.Rows[0]["Book Id"]);
            objCart.Quantity = 1;
            //If book having special price, then unit price should be the special price
            if (Convert.ToInt32(dtBook.Rows[0]["Special Price Status"]) == 1)
            {
                objCart.UnitPrice = Convert.ToInt32(dtBook.Rows[0]["Book Special Price"]);
            }
            else
            {
                objCart.UnitPrice = Convert.ToInt32(dtBook.Rows[0]["Book Price"]);
            }
            objCart.InsertCartDetails();

            Response.Redirect("~/ShoppingCart.aspx");
        }
    }
}