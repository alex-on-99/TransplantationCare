using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransplantationCare.Core.Interfaces.Services;
using TransplantationCare.Core.Interfaces.Validation;
using TransplantationCare.Core.Models.Business;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace TransplantationCare.WEB.API.Controllers.Account
{
    [ApiController]
    public class ClientAccountController : ControllerBase
    {
        private readonly IRegisterValidation registerValidation;
        private readonly ILoginValidation loginValidation;
        private readonly IAccountService accountService;

        public ClientAccountController(
            IRegisterValidation registerValidation,
            IAccountService accountService,
            ILoginValidation loginValidation)
        {
            this.registerValidation = registerValidation;
            this.accountService = accountService;
            this.loginValidation = loginValidation;
        }

        [Route("account/registration")]
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return Ok();
        }

        [Route("account/login")]
        [HttpGet]
        public IActionResult LoginUser()
        {
            return Ok();
        }

        [Route("account/api/create-user")]
        [HttpGet]
        public async Task<IActionResult> CreateUser([FromQuery]RegisterModel model)
        {
            Dictionary<string, string> validationErrors = registerValidation.Validate(model);
            if (validationErrors.Count > 0)
            {
                foreach (var errorPair in validationErrors)
                {
                    ModelState.AddModelError(errorPair.Key, errorPair.Value);
                }
            }

            if (ModelState.IsValid)
            {
                await accountService.RegisterUser(model);
                await Authenticate(model.Login, "Client");
                return RedirectToAction("Index", "Home");
            }

            return BadRequest(ModelState);
        }

        [Route("account/api/signin")]
        [HttpGet]
        public async Task<IActionResult> SignIn([FromQuery]LoginModel model)
        {
            Dictionary<string, string> validationErrors = loginValidation.Validate(model);
            if (validationErrors.Count > 0)
            {
                foreach (var errorPair in validationErrors)
                {
                    ModelState.AddModelError(errorPair.Key, errorPair.Value);
                }
            }

            if (ModelState.IsValid)
            {
                var user = await accountService.Login(model);
                await Authenticate(user.Login, user.Role.Name);
                return RedirectToAction("Index", "Home");
            }

            return BadRequest(ModelState);
        }

        [Route("account/api/logout")]
        [Authorize()]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("LoginUser", "ClientAccount");
        }

        private async Task Authenticate(string login, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
            };
            
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}