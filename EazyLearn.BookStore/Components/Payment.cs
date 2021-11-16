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
        /// gets or sets the customer id
        /// </summary>
        public int CustomerId
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
        /// inserts the payment details like customer id, credit card number, card type, expiry month and year, is deleted
        /// </summary>
        /// <returns>int - number of rows affected</returns>
        public int InsertOrderDetails()
        {
            int numberOfRowsAffected;

            string insertQuery = "insert into bst_payment (pay_customerid, pay_creditcardnumber, pay_creditcardtype, pay_month, " +
                " pay_year, pay_isdeleted) " +
                " values (@customerid, @creditcardnumber, @creditcardtype, @month, @year, @isdeleted); ";

            SqlConnection connectionObj = null;
            SqlCommand cmdInsertPaymentDetails = null;

            try
            {
                connectionObj = DatabaseConnection.GetDatbaseConnection();
                connectionObj.Open();

                cmdInsertPaymentDetails = new SqlCommand(insertQuery, connectionObj);

                cmdInsertPaymentDetails.Parameters.AddWithValue("@customerid", this.CustomerId);
                cmdInsertPaymentDetails.Parameters.AddWithValue("@creditcardnumber", this.CreditCardNumber);
                cmdInsertPaymentDetails.Parameters.AddWithValue("@creditcardtype", this.CreditCardType);
                cmdInsertPaymentDetails.Parameters.AddWithValue("@month", this.Month);
                cmdInsertPaymentDetails.Parameters.AddWithValue("@year", this.Year);
                cmdInsertPaymentDetails.Parameters.AddWithValue("@isdeleted", this.IsDeleted);

                numberOfRowsAffected = cmdInsertPaymentDetails.ExecuteNonQuery();
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