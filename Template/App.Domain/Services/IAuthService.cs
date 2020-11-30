namespace Domain.Services
{
    using Domain.Entities;
    using System.Threading.Tasks;

    public interface IAuthService
    {
        Task<bool> IsAuthenticated();
        Task<bool> IsAnonymous();
        Task<RegisterResult> Register(string email, string password);
        Task<LoginResult> Login(string email, string password);
        Task<User> GetUser();
        Task Logout();
    }
}
