#region Copyright EazyLearn
//
// All rights are reserved. Reproduction or transmission in whole or in part, 
// in any form or by any means, electronic, mechanical or otherwise, is
// prohibited without the prior written consent of the copyright owner.
//
// Filename        : Book.cs    
// Purpose         : To create book object 

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
    public class Book
    {
        #region Public Properties

        /// <summary>
        /// gets or sets the book title
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the author of book
        /// </summary>
        public string Author
        {
            get;
            set;
        }


        /// <summary>
        /// gets or set the category id of a book
        /// </summary>
        public int CategoryId
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets price of a book
        /// </summary>
        public double Price
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the special price status (1 or 0)
        /// </summary>
        public int SpecialPriceStatus
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the Special Price
        /// </summary>
        public double SpecialPrice
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets description of the book
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the status of deletion of book details in book table (1 or 0)
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
        /// inserts book details like title, author, category id, price, special price status, special price,description, is deleted
        /// </summary>
        /// <returns>int - number of rows affected</returns>
        public int InsertBookDetails()
        {
            int numberOfRowsAffected;

            string insertQuery = "procBookInsert";

            SqlConnection connectionObj = null;
            SqlCommand cmd = null;

            try
            {
                connectionObj = DatabaseConnection.GetDatbaseConnection();
                connectionObj.Open();

                cmd = new SqlCommand(insertQuery, connectionObj);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = this.Title;
                cmd.Parameters.Add("@author", SqlDbType.VarChar).Value = this.Author;
                cmd.Parameters.Add("@categoryid", SqlDbType.Int).Value = this.CategoryId;
                cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = this.Price;
                cmd.Parameters.Add("@specialpricestatus", SqlDbType.Bit).Value = this.SpecialPriceStatus;
                cmd.Parameters.Add("@specialprice", SqlDbType.Decimal).Value = this.SpecialPrice;
                cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = this.Description;


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
        /// get all book details from the book table
        /// </summary>
        /// <returns>datatable </returns>
        public DataTable GetAllBookDetails()
        {
            SqlDataAdapter dataAdapterCategory;

            string getQuery = "procBookSelect";
            SqlConnection sqlConnection = null;
            DataTable dt = new DataTable();
            try
            {
                sqlConnection = DatabaseConnection.GetDatbaseConnection();
                sqlConnection.Open();

                dataAdapterCategory = new SqlDataAdapter(getQuery, sqlConnection);
                dataAdapterCategory.Fill(dt);
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
        /// get all book details having special price
        /// </summary>
        /// <returns>dataTable </returns>
        public DataTable GetAllBookWithSpecialPriceDetails()
        {
            SqlDataAdapter dataAdapterCategory;

            string getQuery = "procBookSpecialsSelect";
            SqlConnection sqlConnection = null;
            DataTable dt = new DataTable();
            try
            {
                sqlConnection = DatabaseConnection.GetDatbaseConnection();
                sqlConnection.Open();

                dataAdapterCategory = new SqlDataAdapter(getQuery, sqlConnection);
                dataAdapterCategory.Fill(dt);
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
        /// get all book details except category given the id of book
        /// </summary>
        /// <param name="id"></param>
        /// <returns>dataTable </returns>
        public DataTable GetAllBookDetailsById(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter();


            SqlConnection sqlConnection = null;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            try
            {
                sqlConnection = DatabaseConnection.GetDatbaseConnection();
                sqlConnection.Open();

                cmd = new SqlCommand("procBookByIdDetailsSelect", sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@id", id));
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

        #region Update Methods

        /// <summary>
        /// update book details
        /// </summary>
        /// <returns>int - number of rows updated</returns>
        public int UpdateBookDetails(int id)
        {
            int numberOfRowsAffected;

            string insertQuery = "procBookUpdate";

            SqlConnection connectionObj = null;
            SqlCommand cmd = null;

            try
            {
                connectionObj = DatabaseConnection.GetDatbaseConnection();
                connectionObj.Open();

                cmd = new SqlCommand(insertQuery, connectionObj);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = this.Title;
                cmd.Parameters.Add("@author", SqlDbType.VarChar).Value = this.Author;
                cmd.Parameters.Add("@categoryid", SqlDbType.Int).Value = this.CategoryId;
                cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = this.Price;
                cmd.Parameters.Add("@specialpricestatus", SqlDbType.Bit).Value = this.SpecialPriceStatus;
                cmd.Parameters.Add("@specialprice", SqlDbType.Decimal).Value = this.SpecialPrice;
                cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = this.Description;


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
            return numberOfRowsAffected; //return the number of rows affected
        }
        #endregion

        #endregion
    }
}
