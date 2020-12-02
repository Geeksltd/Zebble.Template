namespace ViewModel
{
    using Domain;
    using System.Threading.Tasks;
    using Zebble.Mvvm;

    class WelcomePage : FullScreen
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

        public void TapLogin() => Forward<LoginPage>();

        public void TapRegister() => Forward<RegisterPage>();
    }
}
