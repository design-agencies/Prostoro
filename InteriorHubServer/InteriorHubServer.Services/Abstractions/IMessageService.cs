using InteriorHubServer.Domain.Contracts;
using InteriorHubServer.Domain.Contracts.Queries;
using InteriorHubServer.Domain.Entities;

namespace InteriorHubServer.Services.Abstractions
{
    public interface IMessageService
    {
        Task<MessageDto> CreateMessageAsync(MessageCreateRequest request);
        Task<IEnumerable<GetDialogsResponse>> GetDialogsAsync(User user);
        Task<int> GetUnreadAsync(User user);
        Task<IEnumerable<MessageDto>> GetMessagesByDialogIdsAsync(long dialogId, User user);
    }
}