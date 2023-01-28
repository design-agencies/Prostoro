using InteriorHubServer.Domain.Contracts;
using InteriorHubServer.Domain.Contracts.Queries;
using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Domain.Interfaces.Repositories;
using InteriorHubServer.Services.Abstractions;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace InteriorHubServer.Services.Impelementations
{
    public class AgencyService : BaseEntityService<Agency>, IAgencyService
    {
        private readonly IUnitOfWork _unitOfWork;
        //public AgencyService(IUnitOfWork unitOfWork, IMapper mapper)
        //{
        //    this._unitOfWork = unitOfWork;
        //    this._mapper = mapper;
        //}
        public AgencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateAsync(AgencyCreateRequest request)
        {
            var agencyAccount = _unitOfWork.UserRepository.FindByCondition(u => string.Equals(u.Email, request.Email), true).FirstOrDefault();
            if(agencyAccount == null)
            {
                return false;
            }
            var agency = new Agency
            {
                Name = request.Name,
                User = agencyAccount,
                IsAvailable = false
            };
            _unitOfWork.AgencyRepository.Create(agency);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<AgencyDetailsGetResponse> GetAgencyByIdAsync(long id, User user = null, bool trackChanges = false)
        {
            var agenciesQ = _unitOfWork.AgencyRepository.FindByCondition(a => a.Id.Equals(id));

            AddIncludeToCollection(ref agenciesQ, null); //???

            var agency = await agenciesQ.FirstOrDefaultAsync();

            var response = new AgencyDetailsGetResponse
            {
                Id = agency.Id,
                UserId = agency.UserId,
                Name = agency.Name,
                LogoImgUrl = agency.LogoImg?.Url,
                HeaderImgUrl = agency.HeaderImg?.Url,
                Description = agency.Description,
                About = agency.About,
                City = agency.City != null ? new CityDto
                {
                    Value = agency.City.Value,
                    En = agency.City.En,
                    Ua = agency.City.Ua,
                } : null,
                Budget = agency.Budget,
                IsVerified = agency.IsVerified,
                RemoteAvailable = agency.RemoteAvailable,
                OnSiteAvailable = agency.OnSiteAvailable,
                Rate = agency.Reviews?.Count > 0 ? (float?)agency.Reviews?.Average(r => r.Rate) : null,
                FollowersCount = 153,
                LikesCount = 398,
                SavesCount = 214,
                //CreatedOn = x.CreatedOn,
                Tags = agency.Tags.Select(x => new TagDto
                {
                    Value = x.Value,
                    Type = x.Type,
                    En = x.En,
                    Ua = x.Ua
                }).ToArray(),
                Reviews = agency.Reviews.Select(x => new ReviewDto
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    UserId = x.UserId,
                    Message = x.Message,
                    Rate = x.Rate,
                    CreatedOn = x.CreatedOn
                }).ToArray()
            };

            if (user != null)
            {
                response.IsSaved = agency.Saves.Any(save => save.UserId == user.Id);
                response.Projects = agency.Projects.Select(x => new AgencyDetailsGetResponse.ProjectDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImgUrl = x.MainImage?.Url,
                    IsLiked = x.Likes.Any(like => like.UserId == user.Id),
                    IsSaved = x.Saves.Any(save => save.UserId == user.Id)
                }).ToArray();
            }
            else
            {
                response.Projects = agency.Projects.Select(x => new AgencyDetailsGetResponse.ProjectDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImgUrl = x.MainImage?.Url
                }).ToArray();
            }

            return response;
        }

        public async Task<AgencyProfileGetResponse> GetAgencyProfileAsync(User user, bool trackChanges = false)
        {
            var agenciesQ = _unitOfWork.AgencyRepository.FindByCondition(a => a.UserId == user.Id);

            AddIncludeToCollection(ref agenciesQ, null); //???

            var agencyProfile = await agenciesQ.FirstOrDefaultAsync();

            return new AgencyProfileGetResponse
            {
                Id = agencyProfile.Id,
                IsAvailable = agencyProfile.IsAvailable,
                UserId = agencyProfile.UserId,
                Name = agencyProfile.Name,
                LogoImgUrl = agencyProfile.LogoImg?.Url,
                HeaderImgUrl = agencyProfile.HeaderImg?.Url,
                ContactFirstName = agencyProfile.ContactFirstName,
                ContactLastName = agencyProfile.ContactLastName,
                Description = agencyProfile.Description,
                About = agencyProfile.About,
                City = agencyProfile.City != null ? new CityDto
                {
                    Value = agencyProfile.City.Value,
                    En = agencyProfile.City.En,
                    Ua = agencyProfile.City.Ua,
                } : null,
                Budget = agencyProfile.Budget,
                IsVerified = agencyProfile.IsVerified,
                RemoteAvailable = agencyProfile.RemoteAvailable,
                OnSiteAvailable = agencyProfile.OnSiteAvailable,
                Rate = 4.5f,
                FollowersCount = 153,
                LikesCount = 398,
                Projects = agencyProfile.Projects.Select(x => new AgencyProfileGetResponse.ProjectDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImgUrl = x.MainImage?.Url
                }).ToArray(),
                SavesCount = 214,
                CreatedOn = agencyProfile.CreatedOn,
                Tags = agencyProfile.Tags?.Select(x => new TagDto
                {
                    Value = x.Value,
                    Type = x.Type,
                    En = x.En,
                    Ua = x.Ua
                }).ToArray(),
                Reviews = agencyProfile.Reviews?.Select(x => new ReviewDto
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    UserId = x.UserId,
                    Message = x.Message,
                    Rate = x.Rate,
                    CreatedOn = x.CreatedOn
                }).ToArray()
            };
        }

        public async Task<bool> UpdateAsync(AgencyUpdateRequest request, long id)
        {
            var agenciesQ = _unitOfWork.AgencyRepository.FindByCondition(a => a.Id.Equals(id), true);

            AddIncludeToCollection(ref agenciesQ, null); //???

            var agency = await agenciesQ.FirstOrDefaultAsync();
            if(request.IsAvailable.HasValue && request.IsAvailable.Value)
            {
                agency.IsAvailable = true;
                return await _unitOfWork.SaveAsync();
            }
            if(request.HeaderImgUrl != null)
            {
                agency.HeaderImg = new Image(request.HeaderImgUrl);
                return await _unitOfWork.SaveAsync();
            }

            agency.Name = request.Name;
            agency.ContactFirstName = request.ContactFirstName;
            agency.ContactLastName = request.ContactLastName;
            agency.User.PhoneNumber = request.PhoneNumber;
            agency.User.Email = request.Email;
            agency.About = request.About;
            agency.Description = request.Description;
            agency.RemoteAvailable = request.RemoteAvailable;
            agency.OnSiteAvailable = request.OnSiteAvailable;
            agency.Budget = request.Budget;
            agency.City = await _unitOfWork.CityRepository.FindByCondition(c => request.City != null && c.Value == request.City.Value, true).FirstOrDefaultAsync();
            //agency.IsAvailable = true; //???
            if(!string.IsNullOrEmpty(request.LogoImgUrl) && !string.Equals(agency.LogoImg?.Url, request.LogoImgUrl))
            {
                agency.LogoImg = new Image(request.LogoImgUrl);
                agency.User.Photo = new Image(request.LogoImgUrl);
            }
            agency.Tags = request.Tags?.Select(t => new Tag(t.Value, t.Type, t.En, t.Ua)).ToList();

            return await _unitOfWork.SaveAsync();
        }

        public async Task<bool> UpdateHeaderImageAsync(string imgUrl, long id)
        {
            var agenciesQ = _unitOfWork.AgencyRepository.FindByCondition(a => a.Id.Equals(id), true);

            AddIncludeToCollection(ref agenciesQ, null); //???

            var agency = await agenciesQ.FirstOrDefaultAsync();

            agency.HeaderImg = new Image(imgUrl);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<AgencyGetResponse>> GetAgenciesAsync(GetAgenciesQuery parameters, User user = null, bool trackChanges = false)
        {
            //var agenciesQ = _unitOfWork.AgencyRepository.FindAll();
            var agenciesQ = _unitOfWork.AgencyRepository.FindAll().Where(a => a.IsAvailable);

            FilterCollection(ref agenciesQ, parameters);

            AddIncludeToCollection(ref agenciesQ, parameters);

            OrderCollection(ref agenciesQ, parameters);

            PaginateCollection(ref agenciesQ, parameters);

            var agencies = await agenciesQ.ToListAsync();

            return agencies.Select(x => new AgencyGetResponse
            {
                Id = x.Id,
                Name = x.Name,
                LogoImgUrl = x.LogoImg?.Url,
                City = x.City != null ? new CityDto
                {
                    Value = x.City.Value,
                    En = x.City.En,
                    Ua = x.City.Ua,
                } : null,
                Budget = x.Budget,
                RemoteAvailable = x.RemoteAvailable,
                OnSiteAvailable = x.OnSiteAvailable,
                Rate = x.Reviews?.Count > 0 ? (float?)x.Reviews?.Average(r => r.Rate) : null,
                //CreatedOn = x.CreatedOn,
                Projects = x.Projects?.Select(x => new AgencyGetResponse.ProjectDto
                {
                    Id = x.Id,
                    ImgUrl = x.MainImage?.Url
                }).ToArray(),
            });
        }

        public async Task<bool> SaveAsync(long agencyId, User user, bool unsave = false)
        {
            if (user == null)
            {
                return false;
            }
            var agenciesQ = _unitOfWork.AgencyRepository.FindByCondition(a => a.Id.Equals(agencyId), true);
            AddIncludeToCollection(ref agenciesQ);
            var agency = await agenciesQ.FirstOrDefaultAsync();
            if (unsave)
            {
                agency.Saves.Remove(agency.Saves.FirstOrDefault(x => x.UserId == user.Id));
            }
            else
            {
                agency.Saves.Add(new Save(user, agency, "agencies"));
            }
            return await _unitOfWork.SaveAsync();
        }

        private void FilterCollection(ref IQueryable<Agency> agencies, GetAgenciesQuery parameters)
        {
            if(parameters.HaveFilters)
            {
                var predicate = PredicateBuilder.New<Agency>();
                if(!string.IsNullOrEmpty(parameters.Budget))
                {
                    predicate = predicate.And(a => a.Budget.Equals(parameters.Budget));
                }
                if (parameters.Tags != null && parameters.Tags.Length != 0)
                {
                    foreach (var tag in parameters.Tags)
                    {
                        predicate = predicate.And(a => a.Tags.Select(t => t.Value).Contains(tag));
                    }
                }
                if (!string.IsNullOrEmpty(parameters.City))
                {
                    predicate = predicate.And(a => a.City.Value.Equals(parameters.City));
                }
                if (parameters.Remote.HasValue && parameters.Remote.Value)
                {
                    predicate = predicate.And(a => a.RemoteAvailable);
                }

                agencies = agencies.Where(predicate);
            }
        }

        private void OrderCollection(ref IQueryable<Agency> agencies, GetAgenciesQuery parameters)
        {
            switch (parameters.OrderBy)
            {
                case "rating":
                    agencies = agencies.OrderByDescending(a => a.Reviews.Average(r => r.Rate));
                    break;
                case "new":
                    agencies = agencies.OrderByDescending(a => a.CreatedOn);
                    break;
                case "cheap":
                    agencies = agencies.OrderBy(a => a.Budget.Length);
                    break;
                case "expensive":
                    agencies = agencies.OrderByDescending(a => a.Budget.Length);
                    break;
            }

        }

        private void AddIncludeToCollection(ref IQueryable<Agency> agencies, GetAgenciesQuery parameters = null)
        {
            agencies = agencies
                .Include(a => a.Projects).ThenInclude(p => p.MainImage)
                .Include(a => a.Projects).ThenInclude(p => p.Likes)
                .Include(a => a.Projects).ThenInclude(p => p.Saves)
                .Include(a => a.Tags)
                .Include(a => a.Saves)
                .Include(a => a.Reviews)
                .Include(a => a.LogoImg)
                .Include(a => a.HeaderImg)
                .Include(a => a.User)
                .Include(a => a.City);
        }
    }
}
