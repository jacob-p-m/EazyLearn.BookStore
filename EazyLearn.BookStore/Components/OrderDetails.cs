#region Copyright EazyLearn
//
// All rights are reserved. Reproduction or transmission in whole or in part, 
// in any form or by any means, electronic, mechanical or otherwise, is
// prohibited without the prior written consent of the copyright owner.
//
// Filename        : OrderDetails.cs    
// Purpose         : To create order details class

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
    public class OrderDetails
    {
        #region Public Properties

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
        public double UnitPrice
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets total amount of a single book
        /// </summary>
        public double TotalAmount
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the Bill amount
        /// </summary>
        public double BillAmount
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
        /// inserts the cart order details like order id, book id, quantity, unit price, total amount, bill amount, is deleted
        /// </summary>
        /// <returns>int - number of rows affected</returns>
        public int InsertOrderDetails()
        {
            int numberOfRowsAffected;

            string insertQuery = "procOrderDetailsInsert";

            SqlConnection connectionObj = null;
            SqlCommand cmd = null;

            try
            {
                connectionObj = DatabaseConnection.GetDatbaseConnection();
                connectionObj.Open();

                cmd = new SqlCommand(insertQuery, connectionObj);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@orderid", SqlDbType.Int).Value = this.OrderId;
                cmd.Parameters.Add("@bookid", SqlDbType.Int).Value = this.BookId;
                cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = this.Quantity;
                cmd.Parameters.Add("@unitprice", SqlDbType.Decimal).Value = this.UnitPrice;
                cmd.Parameters.Add("@totalamount", SqlDbType.Decimal).Value = this.TotalAmount;
                cmd.Parameters.Add("@billamount", SqlDbType.Decimal).Value = this.BillAmount;



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
        /// get order details table given a order id
        /// </summary>
        /// <param name="useremail"></param>
        /// <returns>dataTable </returns>
        public DataTable GetOrderDetailsGivenOrderId(int orderid)
        {
            SqlDataAdapter da = new SqlDataAdapter();


            SqlConnection sqlConnection = null;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            try
            {
                sqlConnection = DatabaseConnection.GetDatbaseConnection();
                sqlConnection.Open();

                cmd = new SqlCommand("procOrderDetailsSelect", sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@orderid", orderid));
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