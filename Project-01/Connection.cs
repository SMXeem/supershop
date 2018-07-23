using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project_01
{
    public class Connection
    {
        private SqlConnection con;

        public SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["robiulsPC"].ConnectionString;
            con = new SqlConnection(connectionString);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            else
            {
                con.Open();
            }
            return con;
        }

        public void GetClose()
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
}