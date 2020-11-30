namespace ViewModel
{
    using Domain.Services;
    using Domain.Services.Firebase;
    using System.Threading.Tasks;
    using Zebble;

    public class WelcomePage : Zebble.Mvvm.FullScreen
    {
        readonly IAuthService AuthService;

        public WelcomePage()
        {
            AuthService = new FirebaseAuthService();
        }

        protected async override Task NavigationStartedAsync()
        {
            var isAuthenticated = await AuthService.IsAuthenticated();

            if (isAuthenticated)
                Go<HomePage>();

            await base.NavigationStartedAsync();
        }

        public void LoginTapped() => Forward<LoginPage>();

        public void RegisterTapped() => Forward<RegisterPage>();
    }
}
