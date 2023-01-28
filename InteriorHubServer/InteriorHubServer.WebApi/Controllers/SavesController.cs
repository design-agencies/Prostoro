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
    public class SavesController : ControllerBase
    {
        private readonly ISaveService _saveService;
        private readonly IAuthService _authService;
        public SavesController(ISaveService saveService, IAuthService authService)
        {
            _saveService = saveService;
            _authService = authService;
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get()
        {
            User user = await _authService.GetUserByName(User.Identity.Name);
            var saves = await _saveService.GetSavesAsync(user);
            var response = new Response<GetSavesResponse>(saves);
            return Ok(response);
        }

        [HttpGet("{folder}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(string folder)
        {
            User user = await _authService.GetUserByName(User.Identity.Name);
            var saves = await _saveService.GetSavesByFolderAsync(user, folder);
            var response = new Response<SavesFolderDto>(saves);
            return Ok(response);
        }
    }
}