using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LMS
{
    public class LMS_connectionString
    {
        public static string connectionString;

        public static SqlConnection GetConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LMS_dBcon"].ToString();

            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
       
    }
}