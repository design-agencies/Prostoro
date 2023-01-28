using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Domain.Interfaces.Repositories;
using InteriorHubServer.Persistence.Contexts;

namespace InteriorHubServer.Persistence.Repositories
{
    public class ErrorInfoRepository : GenericRepositoryBase<ErrorInfo>, IErrorInfoRepository
    {
        public ErrorInfoRepository(DataContext context)
        : base(context) { }
    }
}
