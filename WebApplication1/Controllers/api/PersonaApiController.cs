using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace WebApplication1.Controllers.api
{
    [Route("api/personas")]
    public class PersonaApiController : ApiController
    {
        
        public IHttpActionResult Get(int tipo)
        {
            return Json(new Persona().GetPersonas(null, tipo));
        }


    }





    
}