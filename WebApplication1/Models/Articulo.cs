using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Controllers.connection;

namespace WebApplication1.Models
{
    public class Articulo
    {
        public long Id { get; set; }
        
        public string Nombre { get; set; }

        public string Marca { get; set; }

        public int Estado { get; set; }

        public List<Articulo> GetArticulos(long? id)
        {
            SqlConnection con = ConnectionSqlServer.get();
            SqlCommand com = new SqlCommand("dbo.OBTENERARTICULO", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", id);
            SqlDataReader reader = com.ExecuteReader();
            List<Articulo> Articulos = new List<Articulo>();
            Articulo Articulo = null;
            while (reader.Read())
            {
                Articulo = new Articulo();
                Articulo.Id = long.Parse(reader["ID"].ToString());
                Articulo.Nombre = reader["NOMBRE"].ToString();
                Articulo.Marca = reader["MARCA"].ToString();
                Articulos.Add(Articulo);
            }
            con.Close();
            return Articulos;

        }
    }
}