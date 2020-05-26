using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Raunstrup.Api.Controllers
{
    [Route("Error")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        // GET: api/Error
        [HttpGet]
        public ActionResult Get()
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
