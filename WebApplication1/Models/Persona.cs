using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Controllers.connection;

namespace WebApplication1.Models
{
    public class Persona
    {
        public long Id { get; set; }
        
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        string Sexo { get; set; }

        public int Edad { get; set; }

        public int Estado { get; set; }

        public List<Persona> GetPersonas(long? id, int TipoId)
        {
            SqlConnection con = ConnectionSqlServer.get();
            SqlCommand com = new SqlCommand("dbo.OBTENERPERSONA", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", id);
            com.Parameters.AddWithValue("@TIPOID", TipoId);
            SqlDataReader reader = com.ExecuteReader();
            List<Persona> Personas = new List<Persona>();
            Persona Persona = null;
            while (reader.Read())
            {
                Persona = new Persona();
                Persona.Id = long.Parse(reader["ID"].ToString());
                Persona.Nombre = reader["NOMBRE"].ToString();
                Persona.Apellido = reader["APELLIDO"].ToString();
                Persona.Sexo = reader["SEXO"].ToString();
                Personas.Add(Persona);
            }
            con.Close();
            return Personas;

        }
    }
}
