using InteriorHubServer.Domain.Contracts;
using InteriorHubServer.Domain.Contracts.Queries;
using InteriorHubServer.Domain.Entities;

namespace InteriorHubServer.Services.Abstractions
{
    public interface IProjectService
    {
        //Task<IEnumerable<AgencyGetResponse>> GetProjectsAsync(GetAgenciesQuery parameters, User user = null, bool trackChanges = false);
        //Task<bool> CreateAsync(AgencyCreateRequest agencyDto);
        //void UpdateAsync(AgencyUpdateRequest entity);
        //Task<bool> DeleteAsync(long id);

        Task<ProjectsDetailsGetResponse> GetProjectByIdAsync(long id, User user = null, bool trackChanges = false);
        Task<bool> LikeAsync(long projectId, User user, bool dislike = false);
        Task<bool> SaveAsync(long projectId, User user, bool unsave = false);
    }
}