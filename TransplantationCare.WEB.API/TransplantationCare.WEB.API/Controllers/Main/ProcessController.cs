using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransplantationCare.BusinessLogic.Validation;
using TransplantationCare.Core.Interfaces.Services;
using TransplantationCare.Core.Interfaces.Validation;
using TransplantationCare.Core.Models.Business;

namespace TransplantationCare.WEB.API.Controllers.Main
{
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessService processService;
        private readonly IUserService userService;

        public ProcessController(
            IProcessService processService,
            IUserService userService)
        {
            this.processService = processService;
            this.userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("process/create")]
        public async Task<IActionResult> StartProcess(int contractId)
        {
            var userLogin = User.Identity.Name;
            var user = await userService.GetUserByLogin(userLogin);
            await processService.StartProcess(contractId, user.Id);
            return Ok();
        }
        [HttpGet]
        [Authorize()]
        [Route("process/get")]
        public async Task<IActionResult> GetProcessesByUserId(int processId)
        {
            return Ok(await processService.GetProcessesById(processId));
        }

        [HttpGet]
        [Authorize()]
        [Route("process/user/get")]
        public async Task<IActionResult> GetProcessesByUserId()
        {
            var userLogin = User.Identity.Name;
            var user = await userService.GetUserByLogin(userLogin);
            return Ok(await processService.GetProcessesByUserId(user.Id));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("process-event/admin/get")]
        public async Task<IActionResult> GetAdminEvents()
        {
            var userLogin = User.Identity.Name;
            var user = await userService.GetUserByLogin(userLogin);
            return Ok(await processService.GetEventsByAdminId(user.Id));
        }

        [HttpGet]
        [Authorize(Roles = "Client, Employee")]
        [Route("process-event/user/get")]
        public async Task<IActionResult> GetUserEvents()
        {
            var userLogin = User.Identity.Name;
            var user = await userService.GetUserByLogin(userLogin);
            return Ok(await processService.GetEventsByUserId(user.Id));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("process-event/confirm-execution")]
        public async Task<IActionResult> ConfirmEventExecution(int eventId)
        {
            await processService.ConfirmEventExecution(eventId);
            return Ok();
        }
    }
}