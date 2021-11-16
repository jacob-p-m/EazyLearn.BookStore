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
        public int InsertCartDetails()
        {
            int numberOfRowsAffected;

            string insertQuery = "insert into bst_cart (crt_orderid, crt_bookid, crt_quantity, crt_unitprice, crt_totalamount, " +
                " crt_billamount, crt_isdeleted) " +
                " values (@orderid, @bookid, @quantity, @unitprice, @totalamount, @billamount, @isdeleted); ";

            SqlConnection connectionObj = null;
            SqlCommand cmdInsertCartDetails = null;

            try
            {
                connectionObj = DatabaseConnection.GetDatbaseConnection();
                connectionObj.Open();

                cmdInsertCartDetails = new SqlCommand(insertQuery, connectionObj);

                cmdInsertCartDetails.Parameters.AddWithValue("@orderid", this.OrderId);
                cmdInsertCartDetails.Parameters.AddWithValue("@bookid", this.BookId);
                cmdInsertCartDetails.Parameters.AddWithValue("@quantity", this.Quantity);
                cmdInsertCartDetails.Parameters.AddWithValue("@unitprice", this.UnitPrice);
                cmdInsertCartDetails.Parameters.AddWithValue("@totalamount", this.TotalAmount);
                cmdInsertCartDetails.Parameters.AddWithValue("@billamount", this.BillAmount);
                cmdInsertCartDetails.Parameters.AddWithValue("@isdeleted", this.IsDeleted);

                numberOfRowsAffected = cmdInsertCartDetails.ExecuteNonQuery();
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