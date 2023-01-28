using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Domain.Interfaces.Repositories;
using InteriorHubServer.Persistence.Contexts;

namespace InteriorHubServer.Persistence.Repositories
{
    public class MessageRepository : GenericRepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(DataContext context)
        : base(context) { }
    }
}
