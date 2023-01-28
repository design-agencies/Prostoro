using InteriorHubServer.Domain.Contracts;
using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Domain.Wrappers;
using InteriorHubServer.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InteriorHubServer.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var success = await _authService.RegisterAsync(model);
            if (success)
            {
                return Ok(new RegisterResponse { Status = "Success", Message = "User created successfully!" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new RegisterResponse { Status = "Error", Message = "User creation failed! Please check user details and try again." });
                //throw error
            }
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var login = await _authService.LoginAsync(model);
            if (login != null)
            {
                return Ok(login);
            }
            return Unauthorized();
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> CheckEmail(string email)
        {
            var result = new Response<bool>(await _authService.GetUserByEmail(email) != null);
            return Ok(result);
        }
    }
}