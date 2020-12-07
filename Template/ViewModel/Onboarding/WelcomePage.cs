namespace ViewModel
{
    using Domain;
    using System.Threading.Tasks;
    using Zebble;
    using Zebble.Mvvm;

    class WelcomePage : FullScreen
    {
        readonly IAuthService AuthService;

        public readonly Bindable<string> SampleProperty = new Bindable<string>("Hello world!");
        public Bindable<bool> IsBusy = new Bindable<bool>(false);
        public Bindable<bool> IsAnonymous = new Bindable<bool>(false);
        public readonly Bindable<string> LoggedInUserEmail = new("...");

        public WelcomePage() => AuthService = new FirebaseAuthService();

        protected async override Task NavigationStartedAsync()
        {
            IsBusy.Set(true);

            var isValid = await AuthService.ValidateUserValidity();

            if (isValid)
            {
                var user = await AuthService.GetUser();

                LoggedInUserEmail.Set(user.Email);
            }
            else
                IsAnonymous.Set(true);

            IsBusy.Set(false);

            await base.NavigationStartedAsync();
        }

        public void TapLogin() => Forward<LoginPage>();

        public void TapRegister() => Forward<RegisterPage>();

        public async Task TapLogout()
        {
            IsBusy.Set(true);

            await AuthService.Logout();

            Go<WelcomePage>(PageTransition.SlideBack);

            IsBusy.Set(false);
        }
    }
}
