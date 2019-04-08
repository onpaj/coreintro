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
    public class SettingsController : ControllerBase
    {
        private readonly SettingsClass _settings;

        public SettingsController(SettingsClass settings)
        {
            _settings = settings;
        }


        [HttpGet()]
        public ActionResult<SettingsClass> GetSettings()
        {
            return Ok(_settings);
        }
    }
}
