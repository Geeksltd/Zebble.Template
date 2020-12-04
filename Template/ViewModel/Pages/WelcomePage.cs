namespace ViewModel
{
    using Domain;
    using System.Threading.Tasks;
    using Zebble;
    using Zebble.Mvvm;

    class WelcomePage : FullScreen
    {
        readonly IAuthService AuthService;

        public Bindable<bool> IsBusy = new(false);
        public Bindable<bool> IsAnonymous = new(false);

        public WelcomePage()
        {
            AuthService = new FirebaseAuthService();
        }

        protected async override Task NavigationStartedAsync()
        {
            IsBusy.Set(true);

            var isValid = await AuthService.ValidateUserValidity();

            if (isValid)
                Go<HomePage>();
            else
                IsAnonymous.Set(true);

            IsBusy.Set(false);

            await base.NavigationStartedAsync();
        }

        public void TapLogin() => Forward<LoginPage>();

        public void TapRegister() => Forward<RegisterPage>();
    }
}
