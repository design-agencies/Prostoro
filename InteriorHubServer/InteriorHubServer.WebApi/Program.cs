using InteriorHubServer.Domain.Entities;
using InteriorHubServer.Persistence.Contexts;
using InteriorHubServer.Persistence.TestData;
using InteriorHubServer.WebApi.Controllers;
using InteriorHubServer.WebApi.Extensions;
using InteriorHubServer.WebApi.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title="Prostoro_Api",
        Version="v1",
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name="Authorization",
        Type=SecuritySchemeType.ApiKey,
        Scheme="Bearer",
        BearerFormat="JWT",
        In=ParameterLocation.Header,
        Description="Here enter JWT token"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddDbContext<DataContext>();

builder.Services
    .AddIdentityCore<User>()
    .AddRoles<IdentityRole<long>>() //???
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders(); // ???

#region Auth
builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization()
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ClockSkew = TimeSpan.Zero // removes additional 5 minutes from token lifetime
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];
                if(string.IsNullOrEmpty(accessToken) && context.Request.Headers["Authorization"].Count > 0)
                {
                    accessToken = context.Request.Headers["Authorization"][0];
                }
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) &&
                    (path.StartsWithSegments("/messageHub")))
                {
                    if (accessToken.First().Contains("Bearer"))
                    {
                        accessToken = accessToken.First().Substring(7);
                    }
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };
    });
#endregion Auth

builder.Services.ConfigureCors();
builder.Services.ConfigureUnitOfWork();
builder.Services.ConfigureContracts();
builder.Services.AddSignalR();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{

    //using (var scope = app.Services.CreateScope())
    //{
    //    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    //    dataContext.Database.Migrate();
    //}

    using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope()) // important to use GetService<IServiceScopeFactory>()
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
        var deleted = context.Database.EnsureDeleted();
        var created = context.Database.EnsureCreated();
        TestData.Initialize(context);
    }
}
else
{
    using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope()) // important to use GetService<IServiceScopeFactory>()
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
        //context.Database.EnsureDeleted();
        //context.Database.EnsureCreated();
        //TestData.Initialize(context);
    }
}

app.UseCors("CorsPolicy");

app.UseMiddleware<ErrorHandlerMiddleware>();


app.UseAuthentication();
app.UseAuthorization();
if (!app.Environment.IsDevelopment())
{
    //app.UseHsts(); // ???
    app.UseHttpsRedirection(); // ???
}

app.MapControllers();
app.MapHub<MessageHub>("/messageHub");

if (app.Environment.IsDevelopment())
{
    app.Run("http://localhost:5100");
}
else
{
    app.Run();
}
