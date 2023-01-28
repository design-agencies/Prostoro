using System.ComponentModel.DataAnnotations;

namespace InteriorHubServer.Domain.Contracts
{
    public class AgencyCreateRequest
    {
        //[Required]
        //[StringLength(200, MinimumLength = 1)]
        public string? Name { get; set; }
        public string? Email { get; set; }

    }

    public class AgencyUpdateRequest
    {
        public bool? IsAvailable { get; set; }
        public string? Name { get; set; }
        public string? LogoImgUrl { get; set; }
        public string? HeaderImgUrl { get; set; }
        public string? ContactFirstName { get; set; }
        public string? ContactLastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public string? About { get; set; }
        public CityDto? City { get; set; }
        public string? Budget { get; set; }
        public bool RemoteAvailable { get; set; }
        public bool OnSiteAvailable { get; set; }
        public TagDto[]? Tags { get; set; }
    }

    public class AgencyGetResponse
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? LogoImgUrl { get; set; }
        public CityDto? City { get; set; } // cityId
        public string? Budget { get; set; }
        public bool RemoteAvailable { get; set; }
        public bool OnSiteAvailable { get; set; }
        public float? Rate { get; set; }
        public DateTime CreatedOn { get; set; }
        public ProjectDto[]? Projects { get; set; }

        public class ProjectDto
        {
            public long Id { get; set; }
            public string? ImgUrl { get; set; }
        }
    }

    public class AgencyDetailsGetResponse
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string? Name { get; set; }
        public string? LogoImgUrl { get; set; }
        public string? HeaderImgUrl { get; set; }
        public string? Description { get; set; }
        public string? About { get; set; }
        public CityDto? City { get; set; } // cityId
        public string? Budget { get; set; }
        public bool RemoteAvailable { get; set; }
        public bool OnSiteAvailable { get; set; }
        public bool IsVerified { get; set; }
        public bool IsSaved { get; set; }
        public float? Rate { get; set; }
        public int FollowersCount { get; set; }
        public int LikesCount { get; set; }
        public int SavesCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public ProjectDto[]? Projects { get; set; }
        public ReviewDto[]? Reviews { get; set; }
        public TagDto[]? Tags { get; set; }

        public class ProjectDto
        {
            public long Id { get; set; }
            public string? Name { get; set; }
            public string? ImgUrl { get; set; }
            public bool? IsLiked { get; set; }
            public bool? IsSaved { get; set; }
        }
    }

    public class AgencyProfileGetResponse
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string? Name { get; set; }
        public string? LogoImgUrl { get; set; }
        public string? HeaderImgUrl { get; set; }
        public string? ContactFirstName { get; set; }
        public string? ContactLastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public string? About { get; set; }
        public CityDto? City { get; set; } // cityId
        public string? Budget { get; set; }
        public bool IsVerified { get; set; }
        public bool RemoteAvailable { get; set; }
        public bool OnSiteAvailable { get; set; }
        public bool IsAvailable { get; set; }
        public float Rate { get; set; }
        public int FollowersCount { get; set; }
        public int LikesCount { get; set; }
        public int SavesCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public ProjectDto[]? Projects { get; set; }
        public ReviewDto[]? Reviews { get; set; }
        public TagDto[]? Tags { get; set; }

        public class ProjectDto
        {
            public long Id { get; set; }
            public string? Name { get; set; }
            public string? ImgUrl { get; set; }
        }
    }

    public class AgencySaveDto
    {
        public long AgencyId { get; set; }
        public bool Unsave { get; set; } = false;
    }
}
