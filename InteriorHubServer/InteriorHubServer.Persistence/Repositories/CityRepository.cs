using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Domain.Interfaces.Repositories;
using InteriorHubServer.Persistence.Contexts;

namespace InteriorHubServer.Persistence.Repositories
{
    public class CityRepository : GenericRepositoryBase<City>, ICityRepository
    {
        public CityRepository(DataContext context)
        : base(context) { }
    }
}
