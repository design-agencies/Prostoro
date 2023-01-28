using InteriorHubServer.Domain.Contracts;
using InteriorHubServer.Domain.Contracts.Queries;
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
    public class AgenciesController : ControllerBase
    {
        private readonly IAgencyService _agencyService;
        private readonly IAuthService _authService;

        public AgenciesController(IAgencyService agencyService, IAuthService authService)
        {
            _agencyService = agencyService;
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAgenciesQuery parameters)
        {
            var agencies = await _agencyService.GetAgenciesAsync(parameters);
            var response = new Response<IEnumerable<AgencyGetResponse>>(agencies);
            return Ok(response);
        }

        [HttpGet("{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get(long id)
        {
            User user = null;
            if (User.Identity!.IsAuthenticated)
            {
                user = await _authService.GetUserByName(User.Identity.Name);
            }
            var agency = await _agencyService.GetAgencyByIdAsync(id, user);
            var response = new Response<AgencyDetailsGetResponse>(agency);
            return Ok(response);
        }

        [Route("profile")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Pro,Admin")]
        public async Task<IActionResult> GetAgencyProfile()
        {
            User user;
            if (User.Identity!.IsAuthenticated)
            {
                user = await _authService.GetUserByName(User.Identity.Name);
            }
            else
            {
                return Unauthorized();
            }
            if(user == null)
            {
                return Unauthorized();
            }
            var agency = await _agencyService.GetAgencyProfileAsync(user);
            var response = new Response<AgencyProfileGetResponse>(agency);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AgencyCreateRequest request)
        {

            bool isSaved = await _agencyService.CreateAsync(request);
            if (isSaved)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] AgencyUpdateRequest request, long id)
        {
            bool isUpdated = await _agencyService.UpdateAsync(request, id);
            if (isUpdated)
            {
                return StatusCode(StatusCodes.Status202Accepted);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [Route("save")]
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] AgencySaveDto model)
        {
            User user = null;
            if (User.Identity!.IsAuthenticated)
            {
                user = await _authService.GetUserByName(User.Identity.Name);
                var success = await _agencyService.SaveAsync(model.AgencyId, user, model.Unsave);
                if (success)
                {
                    return Ok();
                }
            }
            return Unauthorized();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _agencyService.DeleteAsync(id);
            if (deleted)
            {
                return Ok();
            }
            else
            {
                throw new Exception(); // internal error, put to service later
            }
        }
    }
}
