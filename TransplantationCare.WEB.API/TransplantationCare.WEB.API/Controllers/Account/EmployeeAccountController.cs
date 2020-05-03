using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransplantationCare.Core.Interfaces.Services;
using TransplantationCare.Core.Interfaces.Validation;
using TransplantationCare.Core.Models.Business;

namespace TransplantationCare.WEB.API.Controllers.Account
{
    [ApiController]
    public class EmployeeAccountController : ControllerBase
    {
        private readonly IEmployeeAccountService employeeAccountService;
        private readonly IRegisterCompanyValidation registerCompanyValidation;
        private readonly IRegisterValidation registerUserValidation;

        public EmployeeAccountController(
            IEmployeeAccountService employeeAccountService,
            IRegisterCompanyValidation registerCompanyValidation,
            IRegisterValidation registerUserValidation)
        {
            this.employeeAccountService = employeeAccountService;
            this.registerCompanyValidation = registerCompanyValidation;
            this.registerUserValidation = registerUserValidation;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("account/company/registration")]
        public IActionResult RegisterUser()
        {
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("account/employee/registration")]
        public IActionResult RegisterEmployee()
        {
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("account/company/api/create")]
        public async Task<IActionResult> CreateCompany([FromQuery]RegisterCompanyModel model)
        {
            var validationErrors = registerCompanyValidation.Validate(model);

            if (validationErrors.Count > 0)
            {
                foreach (var errorPair in validationErrors)
                {
                    ModelState.AddModelError(errorPair.Key, errorPair.Value);
                }
            }

            if (ModelState.IsValid)
            {
                await employeeAccountService.RegisterCompany(model);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("account/employee/api/create")]
        public async Task<IActionResult> CreateEmployee([FromQuery]RegisterEmployeeModel model)
        {
            var validationErrors = registerUserValidation.Validate(model);

            if (validationErrors.Count > 0)
            {
                foreach (var errorPair in validationErrors)
                {
                    ModelState.AddModelError(errorPair.Key, errorPair.Value);
                }
            }

            if (ModelState.IsValid)
            {
                await employeeAccountService.RegisterEmployee(model);
                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}