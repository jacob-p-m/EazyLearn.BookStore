#region Copyright EazyLearn
//
// All rights are reserved. Reproduction or transmission in whole or in part, 
// in any form or by any means, electronic, mechanical or otherwise, is
// prohibited without the prior written consent of the copyright owner.
//
// Filename        : Payment.cs    
// Purpose         : To create customer payment class

// Creation Date   : 09-11-2021
// Author          : Jacob P Mathai
//
// Change History  :
// Changed by      :              
// Date            : 
// Purpose         :
//
#endregion

#region Name spaces
using EazyLearn.BookStore.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

#endregion

namespace EazyLearn.BookStore.Components
{
    public class Payment
    {
        #region Public Properties

        /// <summary>
        /// gets or sets the customer email
        /// </summary>
        public string UserEmail
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the credit card number
        /// </summary>
        public string CreditCardNumber
        {
            get;
            set;
        }

        /// <summary>
        /// gets or set the credit card type
        /// </summary>
        public string CreditCardType
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets credit card expiry month
        /// </summary>
        public string Month
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets credit card expiry year
        /// </summary>
        public string Year
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the status of deletion of payment details(1 or 0)
        /// </summary>
        public int IsDeleted
        {
            get;
            set;
        }

        #endregion

        #region Public Methods

        #region Insert Methods

        /// <summary>
        /// insert payment details of a customer into the database
        /// </summary>
        /// <returns>int - number of rows affected</returns>
        public int InsertPaymentDetails()
        {
            int numberOfRowsAffected;

            string insertQuery = "procPaymentInsert";

            SqlConnection connectionObj = null;
            SqlCommand cmd = null;

            try
            {
                connectionObj = DatabaseConnection.GetDatbaseConnection();
                connectionObj.Open();

                cmd = new SqlCommand(insertQuery, connectionObj);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@useremail", SqlDbType.VarChar).Value = this.UserEmail;
                cmd.Parameters.Add("@cardnumber", SqlDbType.Char).Value = this.CreditCardNumber;
                cmd.Parameters.Add("@cardtype", SqlDbType.VarChar).Value = this.CreditCardType;
                cmd.Parameters.Add("@month", SqlDbType.Char).Value = this.Month;
                cmd.Parameters.Add("@year", SqlDbType.Char).Value = this.Year;


                numberOfRowsAffected = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                connectionObj.Close();
            }
            return numberOfRowsAffected;
        }

        #endregion

        #region List Methods

        /// <summary>
        /// gets card number given useremail
        /// </summary>
        /// <param name="useremail"></param>
        /// <returns>dataTable - card number only</returns>
        public DataTable GetCardNumberGivenUserEmail(string useremail)
        {
            SqlDataAdapter da = new SqlDataAdapter();


            SqlConnection sqlConnection = null;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            try
            {
                sqlConnection = DatabaseConnection.GetDatbaseConnection();
                sqlConnection.Open();

                cmd = new SqlCommand("procPaymentGetCardNumberGivenUserEmail", sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@useremail", useremail));
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

            return dt;
        }

        #endregion
        #endregion
    }
}