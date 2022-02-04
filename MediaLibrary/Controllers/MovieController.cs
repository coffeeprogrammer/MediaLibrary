using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        //[Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var str1 = "Hello Authorize World";
            return Ok(str1);
        }
    }
}
