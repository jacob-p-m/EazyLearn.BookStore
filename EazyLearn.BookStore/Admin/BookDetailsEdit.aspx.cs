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
    public partial class BookDetailsEdit : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fill();
            }
            btnSubmit.ServerClick += new EventHandler(BtnSubmit_Click);
            btnCancel.ServerClick += new EventHandler(BtnCancel_Click);
        }

        void Fill()
        {
            int bookId = Convert.ToInt32(Request.QueryString["bookId"].ToString());

            Book objBook = new Book();
            DataTable dt = objBook.GetAllBookDetailsById(bookId);
            txtTitle.Value = dt.Rows[0]["Book Title"].ToString();
            txtAuthor.Value = dt.Rows[0]["Book Author"].ToString();
            txtPrice.Value = dt.Rows[0]["Book Price"].ToString();
            txtSpecialPrice.Value = dt.Rows[0]["Book Special Price"].ToString();
            txtDescription.Value = dt.Rows[0]["Book Description"].ToString();

            Category objCat = new Category();
            ddlCategory.DataSource = objCat.GetAllCategoryDetails();
            ddlCategory.DataTextField = "Category Name";
            ddlCategory.DataValueField = "Category Id";
            ddlCategory.DataBind();
        }

        void BtnCancel_Click(object sender, EventArgs e)
        {
            Fill();
        }

        void BtnSubmit_Click(object sender, EventArgs e)
        {
            int rowsInserted = 0;

            if (Check(txtTitle.Value))
            {
                ShowMessage("*Enter title");
                return;
            }
            else if (Check(txtAuthor.Value))
            {
                ShowMessage("*Enter author name");
                return;
            }
            else if (Check(txtPrice.Value))
            {
                ShowMessage("*Enter price");
                return;
            }
            else if (Check(txtDescription.Value))
            {
                ShowMessage("*Enter Description");
                return;
            }
            else
            {
                Book objBook = new Book();
                objBook.Title = txtTitle.Value;
                objBook.Author = txtAuthor.Value;
                objBook.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
                objBook.Price = Convert.ToDouble(txtPrice.Value);

                if (txtSpecialPrice.Value == "0" || txtSpecialPrice.Value == "")
                {
                    txtSpecialPrice.Value = "0";
                    objBook.SpecialPriceStatus = 0;
                }
                else
                {
                    objBook.SpecialPriceStatus = 1;
                }

                objBook.SpecialPrice = Convert.ToDouble(txtSpecialPrice.Value);
                objBook.Description = txtDescription.Value;
                int bookId = Convert.ToInt32(Request.QueryString["bookId"].ToString());

                rowsInserted = objBook.UpdateBookDetails(bookId);
            }

            if (rowsInserted > 0)
            {
                ShowMessage("Successfully updated book details");
                Fill();
            }
            else
            {
                ShowMessage("*Data not updated");
            }

        }
        void ShowMessage(string msg)
        {
            txtValidation.InnerText = msg;
        }

        public bool Check(string str)
        {
            if (str == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
