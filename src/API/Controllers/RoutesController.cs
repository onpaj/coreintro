using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        // Single parameter in route
        [HttpGet("byid/{id}")]
        public ActionResult<string> Get(int id)
        {
            return id.ToString();
        }

        // Multiple parameters in route, optional
        // ASP allows you to have route param as optional, but you should not use it in REST api
        [HttpGet("bymultiple/{id}/{id2?}")]
        public ActionResult<string> GetMultiple(int id, int? id2)
        {
            return $"{id} + {id2?.ToString() ?? "NULL"}";
        }


        // Parameter in header and query string
        [HttpGet("byhq")]
        public ActionResult<string> GetFromHeader([FromHeader]string headerValue, [FromQuery]string queryValue)
        {
            return $"Header: {headerValue} | Query: {queryValue}";
        }

        // Parameter in body
        [HttpPut]
        public ActionResult Put([FromBody]InputDto data)
        {
            return Ok();
        }

        // Unknow result type
        [HttpGet("modelunknown")]
        public ActionResult GetModelUnknown()
        {
            return new ObjectResult(new InputDto());
        }


        // Direct type return
        [HttpGet("modelProvidedByReturnValue")]
        public InputDto GetModelProvided()
        {
            return new InputDto();
        }


        // Return type specified by attribute
        [HttpGet("modelProvidedByResponseType")]
        [ProducesResponseType(typeof(InputDto), (int)HttpStatusCode.OK)]
        public ActionResult GetModelProvidedByResponseType()
        {
            return new ObjectResult(new InputDto());
        }

    }
}
