using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TransplantationCare.WEB.API.Controllers.Main
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Client, Admin, Employee")]
        [Route("home/index")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}