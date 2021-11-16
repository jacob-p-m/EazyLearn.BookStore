#region Copyright EazyLearn
//
// All rights are reserved. Reproduction or transmission in whole or in part, 
// in any form or by any means, electronic, mechanical or otherwise, is
// prohibited without the prior written consent of the copyright owner.
//
// Filename        : Category.cs    
// Purpose         : To create category object 

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
    public class Category
    {
        #region Public Properties

        /// <summary>
        /// gets or sets the category name
        /// </summary>
        public string Name
        {
            get;
            set;
        }
 
        /// <summary>
        /// gets or sets the status of deletion of category in category table (1 or 0)
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
        /// inserts the category name, is deleted
        /// </summary>
        /// <returns>int - number of rows affected</returns>
        public int InsertCategoryDetails()
        {
            int numberOfRowsAffected;

            string insertQuery = "insert into bst_category (cat_name) " +
                " values (@name); ";

            SqlConnection connectionObj = null;
            SqlCommand cmdInsertCategoryDetails = null;

            try
            {
                connectionObj = DatabaseConnection.GetDatbaseConnection();
                connectionObj.Open();

                cmdInsertCategoryDetails = new SqlCommand(insertQuery, connectionObj);

                cmdInsertCategoryDetails.Parameters.AddWithValue("@name", this.Name);

                numberOfRowsAffected = cmdInsertCategoryDetails.ExecuteNonQuery();
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
        /// get all categories of books (category table)
        /// </summary>
        /// <returns>datatable - category id and category name</returns>
        public DataTable GetAllCategoryDetails()
        {
            SqlDataAdapter dataAdapterCategory;

            string getQuery = "select cat_id as [Category Id], cat_name as [Category Name] from bst_category where cat_isdeleted = 0";
            SqlConnection sqlConnection = null;
            DataTable dtCategory = new DataTable();
            try
            {
                sqlConnection = DatabaseConnection.GetDatbaseConnection();
                sqlConnection.Open();

                dataAdapterCategory = new SqlDataAdapter(getQuery, sqlConnection);
                dataAdapterCategory.Fill(dtCategory);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }

            return dtCategory;
        }

        #endregion

        #region Update Methods
        
        /// <summary>
        /// update the category table
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns> int - number of rows updated</returns>
        public int UpdateCategoryDetails(int categoryId)
        {
            int numberOfRowsAffected;

            string updateQuery = "update bst_category set cat_name = @name where cat_id = @id";

            SqlConnection connectionObj = null;
            SqlCommand cmdCategoryDetails = null;

            try
            {
                connectionObj = DatabaseConnection.GetDatbaseConnection();
                connectionObj.Open();

                cmdCategoryDetails = new SqlCommand(updateQuery, connectionObj);

                cmdCategoryDetails.Parameters.AddWithValue("@name", this.Name);
                cmdCategoryDetails.Parameters.AddWithValue("@id", categoryId);

                numberOfRowsAffected = cmdCategoryDetails.ExecuteNonQuery();
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

        #region Delete Methods

        /// <summary>
        /// flag a row as deleted in category table
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>int - number of rows deleted</returns>
        public int DeleteCategoryDetails(int categoryId)
        {
            int numberOfRowsAffected;

            string deleteQuery = "update bst_category set cat_isdeleted = 1 where cat_id = @id";

            SqlConnection connectionObj = null;
            SqlCommand cmdCategoryDetails = null;

            try
            {
                connectionObj = DatabaseConnection.GetDatbaseConnection();
                connectionObj.Open();

                cmdCategoryDetails = new SqlCommand(deleteQuery, connectionObj);

                cmdCategoryDetails.Parameters.AddWithValue("@id", categoryId);

                numberOfRowsAffected = cmdCategoryDetails.ExecuteNonQuery();
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
