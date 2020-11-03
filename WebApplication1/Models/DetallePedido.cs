using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Controllers.connection;

namespace WebApplication1.Models
{
    public class DetallePedido
    {
        public long IdPedido { get; set; }
        
        public long Numero { get; set; }

        public long CodigoArticulo { get; set; }

        public int Cantidad { get; set; }

        public long ValorUnidad { get; set; }


        public List<DetallePedido> GetDetallePedido(long? IdPedido)
        {
            SqlConnection con = ConnectionSqlServer.get();
            SqlCommand com = new SqlCommand("dbo.OBTENERDETALLEPEDIDO", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@IDPEDIDO", IdPedido);
            SqlDataReader reader = com.ExecuteReader();
            List<DetallePedido> DetallePedidos = new List<DetallePedido>();
            DetallePedido DetallePedido = null;
            while (reader.Read())
            {
                DetallePedido = new DetallePedido();
                DetallePedido.CodigoArticulo = long.Parse(reader["ARTICULOID"].ToString());
                DetallePedido.Numero = long.Parse(reader["NUMERO"].ToString());
                DetallePedido.ValorUnidad = long.Parse(reader["VALORUNIDAD"].ToString());
                DetallePedido.Cantidad = int.Parse(reader["CANTIDAD"].ToString());
                DetallePedidos.Add(DetallePedido);
            }
            con.Close();
            return DetallePedidos;

        }

    }
}