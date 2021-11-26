using EazyLearn.BookStore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EazyLearn.BookStore
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userEmail = Session["UserEmail"].ToString();
            if (!IsPostBack)
            {
                Cart objCart = new Cart();
                gvCart.DataSource = objCart.GetCartDetailsGivenUserEmail(userEmail);
                gvCart.DataBind();

            }
        }

        protected void gvCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Fill quantity drop-down list
            List<int> quantityList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
            DropDownList ddlQuantity = (DropDownList)e.Row.FindControl("ddlQuantity");
            ddlQuantity.DataSource = quantityList;
            ddlQuantity.DataBind();
            }
        }

        protected void gvCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}