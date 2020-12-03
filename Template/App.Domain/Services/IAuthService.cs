namespace Domain
{
    using System.Threading.Tasks;

    interface IAuthService
    {
        Task<bool> ValidateUserValidity();
        Task<bool> IsAuthenticated();
        Task<bool> IsAnonymous();
        Task<RegisterResult> Register(string email, string password);
        Task<LoginResult> Login(string email, string password);
        Task<User> GetUser();
        Task Logout();
    }
}
