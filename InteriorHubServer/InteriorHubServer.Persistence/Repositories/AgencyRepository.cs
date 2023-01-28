using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Domain.Interfaces.Repositories;
using InteriorHubServer.Persistence.Contexts;

namespace InteriorHubServer.Persistence.Repositories
{
    public class AgencyRepository : GenericRepositoryBase<Agency>, IAgencyRepository
    {
        public AgencyRepository(DataContext context)
        : base(context) { }
    }
}
