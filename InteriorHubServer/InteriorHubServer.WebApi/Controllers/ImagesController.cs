using InteriorHubServer.Domain.Contracts;
using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Domain.Wrappers;
using InteriorHubServer.Services.Abstractions;
using InteriorHubServer.Services.Impelementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InteriorHubServer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IAuthService _authService;

        public ImagesController(IImageService imageService, IAuthService authService)
        {
            _imageService = imageService;
            _authService = authService;
        }

        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromForm] IFormFile image)
        {
            var result = await _imageService.UploadImageAsync(image);
            return Ok(new Response<string>(result.SecureUrl.AbsoluteUri, null));
        }
    }
}
