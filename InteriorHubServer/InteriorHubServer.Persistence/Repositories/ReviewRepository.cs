using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Domain.Interfaces.Repositories;
using InteriorHubServer.Persistence.Contexts;

namespace InteriorHubServer.Persistence.Repositories
{
    public class ReviewRepository : GenericRepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(DataContext context)
        : base(context) { }
    }
}
