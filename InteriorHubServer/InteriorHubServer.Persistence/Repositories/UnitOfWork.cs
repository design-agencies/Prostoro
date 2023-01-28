using InteriorHubServer.Domain.Interfaces.Repositories;
using InteriorHubServer.Persistence.Contexts;

namespace InteriorHubServer.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository => new UserRepository(_context);
        public IProjectRepository ProjectRepository => new ProjectRepository(_context);
        public IAgencyRepository AgencyRepository => new AgencyRepository(_context);
        public IReviewRepository ReviewRepository => new ReviewRepository(_context);
        public IMessageRepository MessageRepository => new MessageRepository(_context);
        public IDialogRepository DialogRepository => new DialogRepository(_context);
        public ISaveRepository SaveRepository => new SaveRepository(_context);
        public ICityRepository CityRepository => new CityRepository(_context);

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
