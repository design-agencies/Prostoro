using InteriorHubServer.Domain.Contracts;
using InteriorHubServer.Domain.Contracts.Queries;
using InteriorHubServer.Domain.Entities;

namespace InteriorHubServer.Services.Abstractions
{
    public interface IReviewService
    {
        Task<ReviewDto> CreateAsync(CreateReviewRequest request, User user);
        void UpdateAsync(AgencyUpdateRequest entity);
        Task<bool> DeleteAsync(long id);
        Task<bool> CreateComplaintAsync(CreateComplaintRequest request, User user);
    }
}
