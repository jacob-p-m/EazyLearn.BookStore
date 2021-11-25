#region Copyright EazyLearn
//
// All rights are reserved. Reproduction or transmission in whole or in part, 
// in any form or by any means, electronic, mechanical or otherwise, is
// prohibited without the prior written consent of the copyright owner.
//
// Filename        : Cart.cs    
// Purpose         : To create cart class

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
    public class Cart
    {
        #region Public Properties

        /// <summary>
        ///gets or sets the email of user  
        /// </summary>
        public string UserEmail
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the order id
        /// </summary>
        public int OrderId
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the Book id
        /// </summary>
        public int BookId
        {
            get;
            set;
        }

        /// <summary>
        /// gets or set the number of books
        /// </summary>
        public int Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets unit price of a book
        /// </summary>
        public int UnitPrice
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets total amount of a single book
        /// </summary>
        public int TotalAmount
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the Bill amount
        /// </summary>
        public int BillAmount
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the status of deletion of cart order details in cart table (1 or 0)
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
        /// insert a book detail into cart for a user
        /// </summary>
        /// <returns>int - number of rows affected</returns>
        public int InsertCartDetails()
        {
            int numberOfRowsAffected;

            string insertQuery = "procCartInsert";

            SqlConnection connectionObj = null;
            SqlCommand cmd = null;

            try
            {
                connectionObj = DatabaseConnection.GetDatbaseConnection();
                connectionObj.Open();

                cmd = new SqlCommand(insertQuery, connectionObj);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@useremail", SqlDbType.VarChar).Value = this.UserEmail;
                cmd.Parameters.Add("@bookid", SqlDbType.Int).Value = this.BookId;
                cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = this.Quantity;
                cmd.Parameters.Add("@unitprice", SqlDbType.Decimal).Value = this.UnitPrice;
                

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
        /// gets the cart details of a user given the useremail
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns>dataTable </returns>
        public DataTable GetCartDetailsGivenUserEmail(string userEmail)
        {
            SqlDataAdapter da = new SqlDataAdapter();


            SqlConnection sqlConnection = null;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            try
            {
                sqlConnection = DatabaseConnection.GetDatbaseConnection();
                sqlConnection.Open();

                cmd = new SqlCommand("procCartSelect", sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@useremail", userEmail));
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

        /// <summary>
        /// gets book details in a cart given book id and useremail
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public DataTable GetCartDetailsGivenUserEmailAndBookId(string userEmail, int bookId)
        {
            SqlDataAdapter da = new SqlDataAdapter();


            SqlConnection sqlConnection = null;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            try
            {
                sqlConnection = DatabaseConnection.GetDatbaseConnection();
                sqlConnection.Open();

                cmd = new SqlCommand("procCartByBookIdAndUserEmailSelect", sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@useremail", userEmail));
                cmd.Parameters.Add(new SqlParameter("@bookid", bookId));
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