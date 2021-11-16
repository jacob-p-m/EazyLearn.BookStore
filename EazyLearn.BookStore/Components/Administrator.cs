#region Copyright EazyLearn
//
// All rights are reserved. Reproduction or transmission in whole or in part, 
// in any form or by any means, electronic, mechanical or otherwise, is
// prohibited without the prior written consent of the copyright owner.
//
// Filename        : Admin.cs    
// Purpose         : To create admin class 

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
    public class Administrator
    {
        #region Public Properties

        /// <summary>
        /// gets or sets the admin username
        /// </summary>
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the admin password
        /// </summary>
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// gets or sets the status of deletion of admin table (1 or 0)
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
        /// inserts the admin name, admin password, is deleted
        /// </summary>
        /// <returns>int - number of rows affected</returns>
        public int InsertAdminDetails()
        {
            int numberOfRowsAffected;

            string insertQuery = "insert into bst_admin (adm_username, adm_password, adm_isdeleted) " +
                " values (@username, @password, @isdeleted); ";

            SqlConnection connectionObj = null;
            SqlCommand cmdInsertAdminDetails = null;

            try
            {
                connectionObj = DatabaseConnection.GetDatbaseConnection();
                connectionObj.Open();

                cmdInsertAdminDetails = new SqlCommand(insertQuery, connectionObj);

                cmdInsertAdminDetails.Parameters.AddWithValue("@username", this.Username);
                cmdInsertAdminDetails.Parameters.AddWithValue("@password", this.Password);
                cmdInsertAdminDetails.Parameters.AddWithValue("@isdeleted", this.IsDeleted);

                numberOfRowsAffected = cmdInsertAdminDetails.ExecuteNonQuery();
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
        /// get the password of an admin for a given admin username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>data table with only one value</returns>
        public DataTable GetAdminPassword()
        {
            SqlCommand cmdObj = new SqlCommand();
            SqlConnection conObj = null;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                conObj = DatabaseConnection.GetDatbaseConnection();
                conObj.Open();

                cmdObj = new SqlCommand("procAdminByUsernamePasswordOutput", conObj);
                cmdObj.Parameters.Add(new SqlParameter("@username", this.Username));
                cmdObj.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmdObj;
                da.Fill(dt);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                conObj.Close();
            }
            return dt;
        }
        #endregion
        #endregion
    }
}
