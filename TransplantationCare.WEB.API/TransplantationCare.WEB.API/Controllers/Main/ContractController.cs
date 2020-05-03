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
    public class ContractController : ControllerBase
    {
        private readonly IContractService contractService;
        private readonly IContractCreationValidation contractValidation;
        private readonly IUserService userService;
        private readonly ICreationUserContractValidation creationUserContractValidation;

        public ContractController(
            IContractService contractService,
            IContractCreationValidation contractValidation,
            IUserService userService,
            ICreationUserContractValidation creationUserContractValidation)
        {
            this.contractService = contractService;
            this.contractValidation = contractValidation;
            this.userService = userService;
            this.creationUserContractValidation = creationUserContractValidation;
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        [Route("contract/api/create")]
        public async Task<IActionResult> CreateContract([FromQuery]ContractCreationModel model)
        {
            var validationErrors = contractValidation.Validate(model);

            if (validationErrors.Count > 0)
            {
                foreach (var errorPair in validationErrors)
                {
                    ModelState.AddModelError(errorPair.Key, errorPair.Value);
                }
            }

            if (ModelState.IsValid)
            {
                var userLogin = User.Identity.Name;
                var user = await userService.GetUserByLogin(userLogin);
                model.CreatorId = user.Id;
                await contractService.CreateContract(model);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        [Authorize()]
        [Route("contract/all-not-revieved")]
        public async Task<IActionResult> GetAllNotRevivedContracts()
        {
            return Ok(await contractService.GetAllNotRevivedContracts());
        }

        [HttpGet]
        [Authorize()]
        [Route("contract/get")]
        public async Task<IActionResult> GetContract([FromQuery]int id)
        {
            return Ok(await contractService.GetContract(id));
        }

        [HttpGet]
        [Authorize()]
        [Route("contract/user/get")]
        public async Task<IActionResult> GetUserContracts()
        {
            var userLogin = User.Identity.Name;
            var user = await userService.GetUserByLogin(userLogin);
            return Ok(await contractService.GetContractsByUserId(user.Id));
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Client")]
        [Route("contract/remove")]
        public async Task<IActionResult> RemoveContract([FromQuery]int id)
        {
            await contractService.RemoveContract(id);

            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("contract/update")]
        public async Task<IActionResult> UpdateContract([FromQuery]ContractUpdateModel model)
        {
            await contractService.UpdateContract(model);

            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        [Route("user-contract/create")]
        public async Task<IActionResult> CreateUserContract([FromQuery]UserContractCreationModel model)
        {
            var userLogin = User.Identity.Name;
            var user = await userService.GetUserByLogin(userLogin);
            model.UserId = user.Id;

            var validationErrors = creationUserContractValidation.Validate(model);

            if (validationErrors.Count > 0)
            {
                foreach (var errorPair in validationErrors)
                {
                    ModelState.AddModelError(errorPair.Key, errorPair.Value);
                }
            }

            if (ModelState.IsValid)
            {
                await contractService.AddUserContract(model);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        [Authorize()]
        [Route("contract/message/add")]
        public async Task<IActionResult> CreateChatMessage([FromQuery]ChatCreatingModel model)
        {
            var userLogin = User.Identity.Name;
            var user = await userService.GetUserByLogin(userLogin);
            model.UserId = user.Id;
            await contractService.AddChatMessage(model);

            return Ok();
        }
    }
}