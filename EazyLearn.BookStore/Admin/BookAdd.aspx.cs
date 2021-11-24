using EazyLearn.BookStore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EazyLearn.BookStore.Admin
{
    public partial class BookAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                FillBoxes();
            }

            btnSubmit.ServerClick += new EventHandler(BtnSubmit_Click);
            btnCancel.ServerClick += new EventHandler(BtnCancel_Click);
            ddlSpecialPriceStatus.SelectedIndexChanged += new EventHandler(SpecialPriceStatusChanged_Click);

        }

        void SpecialPriceStatusChanged_Click(object sender, EventArgs e)
        {
            if (ddlSpecialPriceStatus.SelectedValue == "No")
            {
                txtSpecialPrice.Value = "0.00";
            }
            else
            {
                txtValidation.InnerText = "Enter special price";
            }
        }

        void BtnCancel_Click(object sender, EventArgs e)
        {
            ClearBoxes();
        }
        void FillBoxes()
        {
            Category objCategory = new Category();
            ddlCategory.DataSource = objCategory.GetAllCategoryDetails();
            ddlCategory.DataTextField = "Category Name";
            ddlCategory.DataValueField = "Category Id";
            ddlCategory.DataBind();

            // Special Price Status drop down list initial values
            List<string> specialPriceStatus = new List<string> { "Yes", "No" };
            ddlSpecialPriceStatus.DataSource = specialPriceStatus;
            ddlSpecialPriceStatus.DataBind();
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

                if (ddlSpecialPriceStatus.SelectedValue == "Yes")
                {
                    objBook.SpecialPriceStatus = 1;

                    if (Convert.ToDouble(txtSpecialPrice.Value) > objBook.Price)
                    {
                        ShowMessage("Special price cannot be greater than normal price");
                        return;
                    }
                    if (Convert.ToDouble(txtSpecialPrice.Value) == 0.0)
                    {
                        ShowMessage("Special price cannot be zero");
                        return;
                    }

                }
                else
                {
                    objBook.SpecialPriceStatus = 0;
                }

                objBook.SpecialPrice = Convert.ToDouble(txtSpecialPrice.Value);
                objBook.Description = txtDescription.Value;
                rowsInserted = objBook.InsertBookDetails();
            }

            if (rowsInserted > 0)
            {
                ShowMessage("Successfully inserted book details");
                ClearBoxes();
            }
            else
            {
                ShowMessage("*Data not entered");
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

        void ClearBoxes()
        {
            txtTitle.Value = "";
            txtAuthor.Value = "";
            txtPrice.Value = "";
            txtSpecialPrice.Value = "";
            txtDescription.Value = "";
        }
    }
}
