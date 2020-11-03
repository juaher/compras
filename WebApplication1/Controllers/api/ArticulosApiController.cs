using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace WebApplication1.Controllers.api
{
    [Route("api/articulos")]
    public class ArticulosApiController : ApiController
    {
        [Route("{IdPedido:long}")]
        public IHttpActionResult Get(long IdPedido)
        {
            return Json(new Articulo().GetArticulos(IdPedido));
        }

    }





    
}