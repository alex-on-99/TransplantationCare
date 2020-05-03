using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransplantationCare.Core.Interfaces.Services;

namespace TransplantationCare.WEB.API.Controllers.Main
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Authorize()]
        [Route("user/all")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await userService.GetAllUsers());
        }

        [HttpGet]
        [Authorize()]
        [Route("user/get")]
        public async Task<IActionResult> GetUser([FromQuery]int id)
        {
            return Ok(await userService.GetUser(id));
        }
    }
}