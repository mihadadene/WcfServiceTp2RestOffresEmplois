using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfServiceTp2RestOffresEmplois
{
    public class ConnectionDb
    {

        public static SqlConnection cnx = null;

        public static SqlConnection GetInstance()
        {
            string cs = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=myDB;Integrated Security=True";

            SqlConnection cnx = new SqlConnection(cs);
            try
            {
                cnx.Open();
                Console.WriteLine("Connected...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return cnx;
        }
    }
}