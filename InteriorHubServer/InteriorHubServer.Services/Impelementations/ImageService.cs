using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using InteriorHubServer.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorHubServer.Services.Impelementations
{
    public class ImageService : IImageService
    {
        private readonly Cloudinary _cloudinary;
        public ImageService(IConfiguration config)
        {
            Account account = new Account(
                config.GetSection("CloudinarySettings:CloudName").Value,
                config.GetSection("CloudinarySettings:ApiKey").Value,
                config.GetSection("CloudinarySettings:ApiSecret").Value);

            _cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> UploadImageAsync(IFormFile img)
        {
            var uploadResult = new ImageUploadResult();
            if(img.Length > 0)
            {
                using var stream = img.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(img.Name, stream),
                    //Transformation = new Transformation().Height(600).Width(900)
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }
    }
}
