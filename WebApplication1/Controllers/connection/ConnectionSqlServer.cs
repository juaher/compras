using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication1.Controllers.connection
{
    public static class  ConnectionSqlServer
    {
        public static SqlConnection get()
        {
            var CS1 = ConfigurationManager.ConnectionStrings["sqlserver"];
            String CS =  CS1.ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            con.Open();
            return con;
        }
    }
}