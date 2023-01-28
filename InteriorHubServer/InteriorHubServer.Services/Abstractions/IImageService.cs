using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorHubServer.Services.Abstractions
{
    public interface IImageService
    {
        Task<ImageUploadResult> UploadImageAsync(IFormFile img);
    }
}
