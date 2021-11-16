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
        public int CustomerId
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
        /// inserts order details like order date, customer id, final amount, is deleted
        /// </summary>
        /// <returns>int - number of rows affected</returns>
        public int InsertOrder()
        {
            int numberOfRowsAffected;

            string insertQuery = "insert into bst_order (ord_date, ord_customerid, ord_amount, ord_isdeleted) " +
                " values (@date, @customerid, @amount, @isdeleted); ";

            SqlConnection connectionObj = null;
            SqlCommand cmdInsertOrder = null;

            try
            {
                connectionObj = DatabaseConnection.GetDatbaseConnection();
                connectionObj.Open();

                cmdInsertOrder = new SqlCommand(insertQuery, connectionObj);

                cmdInsertOrder.Parameters.AddWithValue("@date", this.OrderDate);
                cmdInsertOrder.Parameters.AddWithValue("@customerid", this.CustomerId);
                cmdInsertOrder.Parameters.AddWithValue("@amount", this.Amount);
                cmdInsertOrder.Parameters.AddWithValue("@isdeleted", this.IsDeleted);

                numberOfRowsAffected = cmdInsertOrder.ExecuteNonQuery();
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