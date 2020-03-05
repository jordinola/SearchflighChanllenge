using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Searchflight.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        public SearchController()
        {
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}
