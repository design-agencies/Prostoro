using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorHubServer.Domain.Contracts
{
    public class GetSavesResponse
    {
        public SavesFolderDto[] SavesFolders { get; set; }
    }
    public class ProjectSavesDto
    {
        public long Id { get; set; }
        public string ImageUrl { get; set; }
    }
    public class AgencySavesDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string? HeaderImageUrl { get; set; }
        public string LogoImageUrl { get; set; }
    }
    public class SavesFolderDto
    {
        public string Name { get; set; }
        public ProjectSavesDto[]? Projects { get; set; }
        public AgencySavesDto[]? Agencies { get; set; }
    }
}
