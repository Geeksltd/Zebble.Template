namespace ViewModel
{
    using Domain;
    using System.Threading.Tasks;
    using UI.Utils;
    using Zebble;
    using Zebble.Mvvm;

    class HomePage : FullScreen
    {
        readonly IAuthService AuthService;

        public readonly WaitingAwareBindable IsBusy = new(false);
        public readonly Bindable<string> LoggedInUserEmail = new("...");
        public Bindable<string> WelcomeMessage => LoggedInUserEmail.Get(x => $"Welcome back {x}");

        public HomePage() => AuthService = new FirebaseAuthService();

        protected override async Task NavigationStartedAsync()
        {
            using (await IsBusy.SetAsync(true))
            {
                var user = await AuthService.GetUser();

                LoggedInUserEmail.Set(user.Email);
            }

            await base.NavigationStartedAsync();
        }

        public async Task TapLogout()
        {
            IsBusy.Set(true);

            await AuthService.Logout();

            Go<WelcomePage>(PageTransition.SlideBack);

            IsBusy.Set(false);
        }
    }
}
