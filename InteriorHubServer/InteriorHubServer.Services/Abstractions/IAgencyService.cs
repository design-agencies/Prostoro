using InteriorHubServer.Domain.Contracts;
using InteriorHubServer.Domain.Contracts.Queries;
using InteriorHubServer.Domain.Entities;

namespace InteriorHubServer.Services.Abstractions
{
    public interface IAgencyService
    {
        Task<IEnumerable<AgencyGetResponse>> GetAgenciesAsync(GetAgenciesQuery parameters, User user = null, bool trackChanges = false);
        Task<AgencyDetailsGetResponse> GetAgencyByIdAsync(long id, User user = null, bool trackChanges = false);
        Task<AgencyProfileGetResponse> GetAgencyProfileAsync(User user, bool trackChanges = false);
        Task<bool> CreateAsync(AgencyCreateRequest request);
        Task<bool> UpdateAsync(AgencyUpdateRequest request, long id);
        Task<bool> UpdateHeaderImageAsync(string imgUrl, long id);
        Task<bool> DeleteAsync(long id);
        Task<bool> SaveAsync(long agencyId, User user, bool unsave = false);
    }
}
