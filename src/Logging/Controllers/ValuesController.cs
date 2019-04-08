using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Logging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _injectedLogger;
        private readonly ILogger _loggerFromFactory;

        public ValuesController(ILoggerFactory loggerFactory, ILogger<ValuesController> injectedLogger)
        {
            _injectedLogger = injectedLogger;
            _loggerFromFactory = loggerFactory.CreateLogger("LoggerFromFactory");
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _loggerFromFactory.LogInformation("New GET from {MachineName}", Environment.MachineName);
            _injectedLogger.LogInformation("New GET from {MachineName}", Environment.MachineName);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
