namespace Domain.Services
{
    using System.Threading.Tasks;

    public interface IAuthService
    {
        Task<bool> IsAuthenticated();
        Task<bool> IsAnonymous();
        Task<RegisterResult> Register(string email, string password);
        Task<LoginResult> Login(string email, string password);
        Task<UserSession> GetLoggedInUser();
        Task Logout();
    }
}
