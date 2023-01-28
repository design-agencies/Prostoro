using InteriorHubServer.Domain.Contracts;
using InteriorHubServer.Domain.Contracts.Queries;
using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Domain.Interfaces.Repositories;
using InteriorHubServer.Services.Abstractions;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace InteriorHubServer.Services.Impelementations
{
    public class ProjectService : BaseEntityService<Project>, IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProjectsDetailsGetResponse> GetProjectByIdAsync(long id, User user = null, bool trackChanges = false)
        {
            var projectsQ = _unitOfWork.ProjectRepository.FindByCondition(a => a.Id.Equals(id));

            AddIncludeToCollection(ref projectsQ, null); //???
            var project = await projectsQ.FirstOrDefaultAsync();

            var response = new ProjectsDetailsGetResponse
            {
                Id = project.Id,
                Name = project.Name,
                AgencyId = project.Agency?.Id,
                AgencyName = project.Agency.Name,
                AgencyAvatarUrl = project.Agency.LogoImg.Url,
                Elements = project.Elements.OrderBy(x => x.OrderNumber).Select(x => new ProjectsDetailsGetResponse.ProjectElementDto
                {
                    Type = x.Type,
                    Image = x.Type == "image" ? new ProjectsDetailsGetResponse.ProjectImageDto
                    {
                        ImgUrl = x.ProjectImage?.Image?.Url
                    } : null,
                    Text = x.Text
                }).ToArray()
            };

            if (user != null)
            {
                response.IsLiked = project.Likes.Any(like => like.UserId == user.Id);
                response.IsSaved = project.Saves.Any(save => save.UserId == user.Id);
            }

            return response;
        }

        public async Task<bool> LikeAsync(long projectId, User user, bool dislike = false)
        {
            if(user == null)
            {
                return false;
            }
            var projectsQ = _unitOfWork.ProjectRepository.FindByCondition(a => a.Id.Equals(projectId), true);
            AddIncludeToCollection(ref projectsQ);
            var project = await projectsQ.FirstOrDefaultAsync();
            if (dislike)
            {
                project.Likes.Remove(project.Likes.FirstOrDefault(x => x.UserId == user.Id));
            }
            else
            {
                project.Likes.Add(new Like(user, project));
            }
            return await _unitOfWork.SaveAsync();
        }

        public async Task<bool> SaveAsync(long projectId, User user, bool unsave = false)
        {
            if (user == null)
            {
                return false;
            }
            var projectsQ = _unitOfWork.ProjectRepository.FindByCondition(a => a.Id.Equals(projectId), true);
            AddIncludeToCollection(ref projectsQ);
            var project = await projectsQ.FirstOrDefaultAsync();
            if (unsave)
            {
                project.Saves.Remove(project.Saves.FirstOrDefault(x => x.UserId == user.Id));
            }
            else
            {
                project.Saves.Add(new Save(user, project, "projects"));
            }
            return await _unitOfWork.SaveAsync();
        }

        private void AddIncludeToCollection(ref IQueryable<Project> projects)
        {
            projects = projects
                .Include(p => p.Likes)
                .Include(p => p.Saves);
        }

        private void AddIncludeToCollection(ref IQueryable<Project> projects, GetAgenciesQuery parameters)
        {
            projects = projects
                .Include(p => p.Likes).Include(p => p.Saves)
                .Include(p => p.Agency).ThenInclude(a => a.LogoImg)
                .Include(p => p.Elements).ThenInclude(e => e.ProjectImage).ThenInclude(pi => pi.Image);
                //.Include(p => p.).ThenInclude(p => p.Likes)
        }
    }
}
