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
        // https://localhost:5001/api/routes/byid/65
        [HttpGet("byid/{id}")]
        public ActionResult<string> Get(int id)
        {
            return id.ToString();
        }

        // https://localhost:5001/api/routes/bymultiple/65/93
        // https://localhost:5001/api/routes/bymultiple/65
        [HttpGet("bymultiple/{id}/{id2?}")]
        public ActionResult<string> GetMultiple(int id, int? id2)
        {
            return $"{id} + {id2?.ToString() ?? "NULL"}";
        }

        // https://localhost:5001/api/routes/byhq?queryValue=MyQueryValue
        [HttpGet("byhq")]
        public ActionResult<string> GetFromHeader([FromHeader]string headerValue, [FromQuery]string queryValue)
        {
            return $"Header: {headerValue} | Query: {queryValue}";
        }



        [HttpGet("modelunknown")]
        public ActionResult GetModelUnknown()
        {
            return new ObjectResult(new InputDto());
        }


        [HttpGet("modelProvidedByReturnValue")]
        public InputDto GetModelProvided()
        {
            return new InputDto();
        }

        [HttpGet("modelProvidedByResponseType")]
        [ProducesResponseType(typeof(InputDto), (int)HttpStatusCode.OK)]
        public ActionResult GetModelProvidedByResponseType()
        {
            return new ObjectResult(new InputDto());
        }

    }
}
