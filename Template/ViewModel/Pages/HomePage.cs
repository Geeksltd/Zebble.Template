namespace ViewModel
{
    using Domain;
    using System.Threading.Tasks;
    using Zebble;
    using Zebble.Mvvm;

    class HomePage : FullScreen
    {
        readonly IAuthService AuthService;

        public readonly Bindable<bool> IsBusy = new(false);
        public readonly Bindable<string> LoggedInUserEmail = new("joe@doe.com");

        public HomePage()
        {
            AuthService = new FirebaseAuthService();
        }

        protected override async Task NavigationStartedAsync()
        {
            IsBusy.Set(true);

            var user = await AuthService.GetUser();

            LoggedInUserEmail.Set(user.Email);

            IsBusy.Set(false);

            await base.NavigationStartedAsync();
        }

        public async Task TapLogout()
        {
            await AuthService.Logout();

            Go<WelcomePage>(PageTransition.SlideBack);
        }
    }
}
