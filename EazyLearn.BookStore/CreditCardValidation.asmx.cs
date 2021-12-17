using EazyLearn.BookStore.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EazyLearn.BookStore
{
    /// <summary>
    /// Given credit card details, it will check whether it is a valid credit card or not
    /// </summary>
    [WebService(Namespace = "http://creditcardvalidation.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CreditCardValidation : System.Web.Services.WebService
    {

        [WebMethod]
        public bool ValidateCreditCard(string cardtype, string cardnumber, string month, string year, string cvv)
        {
            SqlDataAdapter da = new SqlDataAdapter();

            SqlConnection sqlConnection = null;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            try
            {
                sqlConnection = DatabaseConnection.GetDatbaseConnection();
                sqlConnection.Open();

                cmd = new SqlCommand("procCreditCardValidation", sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@cardnumber", cardnumber));
                cmd.Parameters.Add(new SqlParameter("@month", month));
                cmd.Parameters.Add(new SqlParameter("@year", year));
                cmd.Parameters.Add(new SqlParameter("@cvv", cvv));
                cmd.Parameters.Add(new SqlParameter("@cardtype", cardtype));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }

            if (dt.Rows.Count > 0)
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
