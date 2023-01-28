using InteriorHubServer.Domain.Contracts;
using InteriorHubServer.Domain.Contracts.Queries;
using InteriorHubServer.Domain.Entities;

namespace InteriorHubServer.Services.Abstractions
{
    public interface ISaveService
    {
        Task<GetSavesResponse> GetSavesAsync(User user, bool trackChanges = false);
        Task<SavesFolderDto> GetSavesByFolderAsync(User user, string folder, bool trackChanges = false);
    }
}
