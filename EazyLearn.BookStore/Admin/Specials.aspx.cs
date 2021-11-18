using EazyLearn.BookStore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EazyLearn.BookStore.Admin
{
    public partial class Specials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Fill();
        }

        void Fill()
        {
            Book objBook = new Book();
            gvSpecials.DataSource = objBook.GetAllBookWithSpecialPriceDetails();
            gvSpecials.DataBind();
        }

        protected void gvSpecials_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Fill();
            gvSpecials.PageIndex = e.NewPageIndex;
            gvSpecials.DataBind();
        }
    }
}
