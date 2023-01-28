using InteriorHubServer.Domain.Contracts;
using InteriorHubServer.Domain.Entities;

namespace InteriorHubServer.Services.Abstractions
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterModel model);
        Task<LoginResponse> LoginAsync(LoginModel model);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByName(string username);
        Task<User> GetUserById(long id);
    }
}
