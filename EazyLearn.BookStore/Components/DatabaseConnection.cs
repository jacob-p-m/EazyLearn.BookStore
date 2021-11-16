#region Copyright EazyLearn
//
// All rights are reserved. Reproduction or transmission in whole or in part, 
// in any form or by any means, electronic, mechanical or otherwise, is
// prohibited without the prior written consent of the copyright owner.
//
// Filename        : DatabaseConnection.cs
// Purpose         : To make database connection 

// Creation Date   : 09-11-2021
// Author          : Jacob P Mathai
//
// Change History  :
// Changed by      :              
// Date            : 
// Purpose         :
//  
#endregion Copyright EazyLearn

#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Included Namespaces

namespace EazyLearn.BookStore.Components
{
    class DatabaseConnection
    {
        #region Public Static Properties

        /// <summary>
        /// Connection string
        /// </summary>
        public static string ConnectionString
        {
            get;
            set;
        }
        #endregion Public Static Properties

        #region Public Static Methods

        /// <summary>
        /// To create database object for database connection
        /// </summary>
        /// <returns>Connection object</returns>
        public static SqlConnection GetDatbaseConnection()
        {
            SqlConnection connectionObject;
            ConnectionString = ConfigurationManager.ConnectionStrings["firstConnection"].ConnectionString;
            connectionObject = new SqlConnection(ConnectionString);

            return connectionObject;
        }
        #endregion Public Static Properties
    }
}
