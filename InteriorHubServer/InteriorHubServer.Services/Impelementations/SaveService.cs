using InteriorHubServer.Domain.Contracts;
using InteriorHubServer.Domain.Contracts.Queries;
using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Domain.Interfaces.Repositories;
using InteriorHubServer.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace InteriorHubServer.Services.Impelementations
{
    public class SaveService : ISaveService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SaveService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetSavesResponse> GetSavesAsync(User user, bool trackChanges = false)
        {
            var savesQ = _unitOfWork.SaveRepository.FindByCondition(x => x.UserId == user.Id);

            AddIncludeToCollection(ref savesQ);

            var saves = await savesQ.ToListAsync();

            var folders = saves.GroupBy(x => x.Folder);
            var response = new GetSavesResponse
            {
                SavesFolders = folders.Select(x => new SavesFolderDto
                {
                    Name = x.FirstOrDefault().Folder,
                    Projects = x.Where(s => s.ProjectId.HasValue).Select(s => new ProjectSavesDto
                    {
                        Id = s.ProjectId!.Value,
                        ImageUrl = s.Project!.MainImage!.Url
                    }).Take(4).ToArray(),
                    Agencies = x.Where(s => s.AgencyId.HasValue).Select(s => new AgencySavesDto
                    {
                        Id = s.AgencyId!.Value,
                        HeaderImageUrl = s.Agency!.HeaderImg.Url,
                        LogoImageUrl = s.Agency!.LogoImg.Url
                    }).Take(4).ToArray()
                }).ToArray()
            };
            return response;
        }

        public async Task<SavesFolderDto> GetSavesByFolderAsync(User user, string folder, bool trackChanges = false)
        {
            var savesQ = _unitOfWork.SaveRepository.FindByCondition(x => x.UserId == user.Id && x.Folder.Equals(folder));

            AddIncludeToCollection(ref savesQ);

            var saves = await savesQ.ToListAsync();

            return new SavesFolderDto
            {
                Name = folder,
                Projects = saves.Where(s => s.ProjectId.HasValue).Select(s => new ProjectSavesDto
                {
                    Id = s.ProjectId!.Value,
                    ImageUrl = s.Project!.MainImage!.Url
                }).ToArray(),
                Agencies = saves.Where(s => s.AgencyId.HasValue).Select(s => new AgencySavesDto
                {
                    Id = s.AgencyId!.Value,
                    Name = s.Agency.Name,
                    City = s.Agency.City.Ua,
                    HeaderImageUrl = s.Agency!.HeaderImg.Url,
                    LogoImageUrl = s.Agency!.LogoImg.Url
                }).ToArray()
            };
        }

        private void AddIncludeToCollection(ref IQueryable<Save> saves)
        {
            saves = saves.Include(x => x.Project).ThenInclude(p => p.MainImage)
                .Include(x => x.Agency).ThenInclude(a => a.City)
                .Include(x => x.Agency).ThenInclude(a => a.HeaderImg)
                .Include(x => x.Agency).ThenInclude(a => a.LogoImg);
        }
    }
}