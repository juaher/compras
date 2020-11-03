using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Controllers.connection;

namespace WebApplication1.Models
{
    public class Pedido
    {
        public long Id { get; set; }
        
        public long Cliente { get; set; }

        public long Vendedor { get; set; }

        public String FechaHora { get; set; }

        public String NombreCliente { get; set; }

        public int Estado { get; set; }

        public List<DetallePedido> DetallePedidos { get; set; }

        
        public long SavePedido()
        {

            SqlConnection con = ConnectionSqlServer.get();
            SqlCommand com = new SqlCommand("dbo.CREARPEDIDO", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CLIENTE", Cliente);
            com.Parameters.AddWithValue("@VENDEDOR", Vendedor);
            com.Parameters.Add("@NEWId", SqlDbType.BigInt).Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            long IdPedido = long.Parse(com.Parameters["@NEWId"].Value.ToString());
            foreach (DetallePedido detalle in DetallePedidos) {
                com = new SqlCommand("dbo.CREARDETALLEPEDIDO", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@PEDIDOID", IdPedido);
                com.Parameters.AddWithValue("@ARTICULOID", detalle.CodigoArticulo);
                com.Parameters.AddWithValue("@NUMERO", detalle.Numero);
                com.Parameters.AddWithValue("@CANTIDAD", detalle.Cantidad);
                com.Parameters.AddWithValue("@VALORUNIDAD", detalle.ValorUnidad);
                com.Parameters.Add("@NEWId", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();
            }
            con.Close();
            return IdPedido;
        }

        public List<Pedido> GetPedidos(long? id, long? vendedor)
        {
            SqlConnection con = ConnectionSqlServer.get();
            SqlCommand com = new SqlCommand("dbo.OBTENEPEDIDO", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", id);
            com.Parameters.AddWithValue("@IDVENDEDOR", vendedor);
            SqlDataReader reader = com.ExecuteReader();
            List<Pedido> Pedidos = new List<Pedido>();
            Pedido Pedido = null;
            while (reader.Read())
            {
                Pedido = new Pedido();
                Pedido.Id = long.Parse(reader["ID"].ToString());
                Pedido.FechaHora = reader["FECHA"].ToString();
                Pedido.NombreCliente = reader["NOMBRE"].ToString();
                Pedidos.Add(Pedido);
            }
            con.Close();
            return Pedidos;

        }

        public void Eliminar(long Id)
        {
            SqlConnection con = ConnectionSqlServer.get();
            SqlCommand com = new SqlCommand("dbo.ELIMINARPEDIDO", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", Id);
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}