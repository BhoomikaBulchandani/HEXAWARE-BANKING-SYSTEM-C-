using System;
using Microsoft.Data.SqlClient;


namespace Utility_Library
{
    public class DBUtil
    {
        private static readonly string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=HMBank;Integrated Security=True;Trust Server Certificate=True";

        public static SqlConnection getDBConn()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error establishing database connection: " + ex.Message);
                return null;
            }
        }
    }
}
