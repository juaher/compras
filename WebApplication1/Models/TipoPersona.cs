using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TipoPersona
    {
        public long IdPersona { get; set; }
        
        public int Tipo { get; set; }

        public int Estado { get; set; }
    }
}