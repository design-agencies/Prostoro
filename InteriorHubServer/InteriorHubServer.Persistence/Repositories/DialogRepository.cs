using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Domain.Interfaces.Repositories;
using InteriorHubServer.Persistence.Contexts;

namespace InteriorHubServer.Persistence.Repositories
{
    public class DialogRepository : GenericRepositoryBase<Dialog>, IDialogRepository
    {
        public DialogRepository(DataContext context)
        : base(context) { }
    }
}
