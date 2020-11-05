using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace WebApplication1.Controllers.api
{
    [RoutePrefix("api/personas")]
    public class PersonaApiController : ApiController
    {

        [Route("{Tipo:int}")]
        public IHttpActionResult Get(int Tipo)
        {
            return Json(new Persona().GetPersonas(null, Tipo));
        }


    }





    
}