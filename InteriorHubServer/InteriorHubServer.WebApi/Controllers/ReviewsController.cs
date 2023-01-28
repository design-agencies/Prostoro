using InteriorHubServer.Domain.Contracts;
using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InteriorHubServer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IAuthService _authService;

        public ReviewsController(IReviewService reviewService, IAuthService authService)
        {
            _reviewService = reviewService;
            _authService = authService;
        }

        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromBody] CreateReviewRequest request)
        {
            if (User.Identity!.IsAuthenticated)
            {
                User user = await _authService.GetUserByName(User.Identity.Name);
                var result = await _reviewService.CreateAsync(request, user);
                return Ok(result);
            }
            return Unauthorized();
        }

        [Route("complaint")]
        [HttpPost]
        public async Task<IActionResult> CreateComplaint([FromBody] CreateComplaintRequest request)
        {
            if (User.Identity!.IsAuthenticated)
            {
                User user = await _authService.GetUserByName(User.Identity.Name);
                await _reviewService.CreateComplaintAsync(request, user);
                return Ok();
            }
            return Unauthorized();
        }
    }
}
