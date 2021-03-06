﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DerivedController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return this.GetType().Name;
        }

        [HttpPut]
        public ActionResult Put(InputDto model)
        {
            return Ok();
        }
    }
}
