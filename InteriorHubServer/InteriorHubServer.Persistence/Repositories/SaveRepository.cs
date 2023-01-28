using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Domain.Interfaces.Repositories;
using InteriorHubServer.Persistence.Contexts;

namespace InteriorHubServer.Persistence.Repositories
{
    public class SaveRepository : GenericRepositoryBase<Save>, ISaveRepository
    {
        public SaveRepository(DataContext context)
        : base(context) { }
    }
}
