using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace InteriorHubServer.Domain.Contracts
{
    public class ProjectCreateRequest
    {
        [Required]
        //[StringLength(200, MinimumLength = 1)]
        public string? Name { get; set; }
        public TagDto[]? Tags { get; set; }
        public long AgencyId { get; set; }
        public string? MainImage { get; set; }
        public ProjectElementDto[]? Elements { get; set; }
        public class ProjectElementDto
        {
            public int Key { get; set; }
            public string Type { get; set; }
            public ProjectImageDto? Image { get; set; }
            public string? Text { get; set; }
        }
        public class ProjectImageDto
        {
            public string? ImgUrl { get; set; }
            public TagDto[]? Tags { get; set; }
        }
    }

    public class ProjectLikeDto
    {
        public long ProjectId { get; set; }
        public bool Dislike { get; set; } = false;
    }

    public class ProjectSaveDto
    {
        public long ProjectId { get; set; }
        public bool Unsave { get; set; } = false;
    }

    public class ProjectsDetailsGetResponse
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool? IsLiked { get; set; }
        public bool? IsSaved { get; set; }
        public long? AgencyId { get; set; }
        public string? AgencyName { get; set; }
        public string? AgencyAvatarUrl { get; set; }
        public ProjectElementDto[] Elements { get; set; }

        public class ProjectElementDto
        {
            public string Type { get; set; }
            public ProjectImageDto? Image { get; set; }
            public string? Text { get; set; }
        }
        public class ProjectImageDto
        {
            public string ImgUrl { get; set; }
        }
    }
}
