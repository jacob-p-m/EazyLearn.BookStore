#region Copyright EazyLearn
//
// All rights are reserved. Reproduction or transmission in whole or in part, 
// in any form or by any means, electronic, mechanical or otherwise, is
// prohibited without the prior written consent of the copyright owner.
//
// Filename        : Order.cs    
// Purpose         : To create orders object 

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
    public class Order
    {
        #region Public Properties

        /// <summary>
        /// gets or sets the Date of order
        /// </summary>
        public DateTime OrderDate
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the customer id
        /// </summary>
        public string UserEmail
        {
            get;
            set;
        }

        /// <summary>
        /// gets or set the final amount of order
        /// </summary>
        public int Amount
        {
            get;
            set;
        }

   

        /// <summary>
        /// gets or sets the status of deletion of order(1 or 0)
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
        /// inserts customer email
        /// </summary>
        /// <returns>int - number of rows affected</returns>
        public int InsertOrderDetails()
        {
            int numberOfRowsAffected;

            string insertQuery = "procOrderInsert";

            SqlConnection connectionObj = null;
            SqlCommand cmd = null;

            try
            {
                connectionObj = DatabaseConnection.GetDatbaseConnection();
                connectionObj.Open();

                cmd = new SqlCommand(insertQuery, connectionObj);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@useremail", SqlDbType.VarChar).Value = this.UserEmail;



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

        /// <summary>
        /// get order table details given useremail
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="bookId"></param>
        /// <returns>dataTable </returns>
        public DataTable GetOrderDetailsGivenUserEmail(string useremail)
        {
            SqlDataAdapter da = new SqlDataAdapter();


            SqlConnection sqlConnection = null;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            try
            {
                sqlConnection = DatabaseConnection.GetDatbaseConnection();
                sqlConnection.Open();

                cmd = new SqlCommand("procOrderByUserEmailSelect", sqlConnection);
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