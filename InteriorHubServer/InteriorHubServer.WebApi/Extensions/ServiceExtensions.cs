using InteriorHubServer.Domain.Interfaces.Repositories;
using InteriorHubServer.Persistence.Repositories;
using InteriorHubServer.Services.Abstractions;
using InteriorHubServer.Services.Impelementations;
using Microsoft.AspNetCore.Server.IISIntegration;

namespace InteriorHubServer.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    //builder => builder.AllowAnyOrigin()
                    builder => builder.WithOrigins("http://localhost:4200", "https://prostoro-ua.web.app", "http://localhost:56375")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            //services.AddAuthentication(IISDefaults.AuthenticationScheme); // ???
        }

        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureContracts(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAgencyService, AgencyService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<ISaveService, SaveService>();
            services.AddScoped<IImageService, ImageService>();
        }
    }
}
