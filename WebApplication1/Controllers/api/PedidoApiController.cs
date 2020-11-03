using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace WebApplication1.Controllers.api
{
    [RoutePrefix("api/pedidos")]
    public class PedidoApiController : ApiController
    {
        [Route("")]
        public IHttpActionResult Put(Pedido Pedido)
        {
            return Json(Pedido.SavePedido());
        }

        [Route("PorVendedor/{Vendedor:long}")]
        public IHttpActionResult GetPorVendedor(long Vendedor)
        {
            return Json(new Pedido().GetPedidos(null, Vendedor));
        }
        
        [Route("{Id:long}")]
        public IHttpActionResult Get(long Id)
        {
            return Json(new Pedido().GetPedidos(Id, null));
        }

        [Route("{IdPedido:long}")]
        public IHttpActionResult Delete(long IdPedido)
        {
            new Pedido().Eliminar(IdPedido);
            return Json("Elimando.");
        }

    }





    
}