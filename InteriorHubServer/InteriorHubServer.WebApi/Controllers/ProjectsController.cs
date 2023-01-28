using InteriorHubServer.Domain.Contracts;
using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Domain.Interfaces.Repositories;
using InteriorHubServer.Domain.Wrappers;
using InteriorHubServer.Services.Abstractions;
using InteriorHubServer.Services.Impelementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InteriorHubServer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        IImageService _imageService;
        IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        private readonly IProjectService _projectService;
        public ProjectsController(IImageService imageService, IUnitOfWork unitOfWork, IProjectService projectService, IAuthService authService)
        {
            _imageService = imageService;
            _unitOfWork = unitOfWork;
            _projectService = projectService;
            _authService = authService;
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
            var project = await _projectService.GetProjectByIdAsync(id, user);
            var response = new Response<ProjectsDetailsGetResponse>(project);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Pro")]
        public async Task<IActionResult> Post([FromBody] ProjectCreateRequest projectDto)
        {
            User user = null;
            if (User.Identity!.IsAuthenticated)
            {
                user = await _authService.GetUserByName(User.Identity.Name);
            }
            var agency = await _unitOfWork.AgencyRepository.FindByCondition(a => a.UserId == user.Id).FirstOrDefaultAsync();
            var project = new Project
            {
                Name = projectDto.Name,
                AgencyId = agency.Id,
                MainImage = new Image(projectDto.MainImage),
                Elements = projectDto.Elements?.Select(el => new ProjectElement
                {
                    OrderNumber = el.Key,
                    Type = el.Type,
                    ProjectImage = el.Type == "image" ? new ProjectImage
                    {
                        Image = new Image(el.Image.ImgUrl),
                        Tags = el.Image.Tags?.Select(tag => new Tag(tag.Value, tag.Type, tag.En, tag.Ua)).ToArray()
                    } : null,
                    Text = el.Type == "text" ? el.Text : null,
                }).ToArray()
            };
            _unitOfWork.ProjectRepository.Create(project);
            var result = await _unitOfWork.SaveAsync();
            

            return Ok(201);
        }
        [Route("like")]
        [HttpPost]
        public async Task<IActionResult> Like([FromBody] ProjectLikeDto model)
        {
            User user = null;
            if (User.Identity!.IsAuthenticated)
            {
                user = await _authService.GetUserByName(User.Identity.Name);
                var success = await _projectService.LikeAsync(model.ProjectId, user, model.Dislike);
                if(success)
                {
                    return Ok();
                }
            }
            return Unauthorized();
        }

        [Route("save")]
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] ProjectSaveDto model)
        {
            User user = null;
            if (User.Identity!.IsAuthenticated)
            {
                user = await _authService.GetUserByName(User.Identity.Name);
                var success = await _projectService.SaveAsync(model.ProjectId, user, model.Unsave);
                if (success)
                {
                    return Ok();
                }
            }
            return Unauthorized();
        }
    }
}
