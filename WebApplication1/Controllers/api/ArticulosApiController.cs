using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace WebApplication1.Controllers.api
{
    [RoutePrefix("api/articulos")]
    public class ArticulosApiController : ApiController
    {
        [Route("PorPedido/{IdPedido:long}")]
        public IHttpActionResult GetPorPedido(long IdPedido)
        {
            return Json(new Articulo().GetArticulos(IdPedido));
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Json(new Articulo().GetArticulos(null));
        }

    }





    
}