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
        /// inserts the cart order details like order id, book id, quantity, unit price, total amount, bill amount, is deleted
        /// </summary>
        /// <returns>int - number of rows affected</returns>
        public int InsertOrderDetails()
        {
            int numberOfRowsAffected;

            string insertQuery = "insert into bst_orderdetails (odd_orderid, odd_bookid, odd_quantity, odd_unitprice, odd_totalamount, " +
                " odd_billamount, odd_isdeleted) " +
                " values (@orderid, @bookid, @quantity, @unitprice, @totalamount, @billamount, @isdeleted); ";

            SqlConnection connectionObj = null;
            SqlCommand cmdInsertOrderDetails = null;

            try
            {
                connectionObj = DatabaseConnection.GetDatbaseConnection();
                connectionObj.Open();

                cmdInsertOrderDetails = new SqlCommand(insertQuery, connectionObj);

                cmdInsertOrderDetails.Parameters.AddWithValue("@orderid", this.OrderId);
                cmdInsertOrderDetails.Parameters.AddWithValue("@bookid", this.BookId);
                cmdInsertOrderDetails.Parameters.AddWithValue("@quantity", this.Quantity);
                cmdInsertOrderDetails.Parameters.AddWithValue("@unitprice", this.UnitPrice);
                cmdInsertOrderDetails.Parameters.AddWithValue("@totalamount", this.TotalAmount);
                cmdInsertOrderDetails.Parameters.AddWithValue("@billamount", this.BillAmount);
                cmdInsertOrderDetails.Parameters.AddWithValue("@isdeleted", this.IsDeleted);

                numberOfRowsAffected = cmdInsertOrderDetails.ExecuteNonQuery();
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
        #endregion
    }
}