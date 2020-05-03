using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransplantationCare.Core.Interfaces.Services;
using TransplantationCare.Core.Models.Business;

namespace TransplantationCare.WEB.API.Controllers.Main
{
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet]
        [Authorize()]
        [Route("review/create")]
        public async Task<IActionResult> CreateReview([FromQuery]ReviewCreationModel model)
        {
            model.ReviewerLogin = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            model.DateTimeReview = DateTime.Now;
            await reviewService.CreateReview(model);
            return Ok();
        }
    }
}