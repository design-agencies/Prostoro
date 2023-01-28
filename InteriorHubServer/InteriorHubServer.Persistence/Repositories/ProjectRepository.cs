using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Domain.Interfaces.Repositories;
using InteriorHubServer.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorHubServer.Persistence.Repositories
{
    public class ProjectRepository : GenericRepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(DataContext context)
        : base(context) { }
    }
}
