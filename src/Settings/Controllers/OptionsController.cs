using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Settings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly IOptionsMonitor<SettingsClass> _options;

        public OptionsController(IOptionsMonitor<SettingsClass> options)
        {
            _options = options;
        }


        [HttpGet]
        public ActionResult<SettingsClass> GetSettings()
        {
            return Ok(_options.CurrentValue);
        }
    }
}
