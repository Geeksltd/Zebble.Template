namespace ViewModel
{
    using Domain;
    using System.Threading.Tasks;
    using Zebble;
    using Zebble.Mvvm;

    class WelcomePage : FullScreen
    {
        readonly IAuthService AuthService;

        public Bindable<bool> IsIniting = new(true);
        public Bindable<bool> IsAnonymous = new(false);

        public WelcomePage()
        {
            AuthService = new FirebaseAuthService();
        }

        protected async override Task NavigationStartedAsync()
        {
            var isValid = await AuthService.ValidateUserValidity();

            IsIniting.Set(false);

            if (isValid)
                Go<HomePage>();
            else
                IsAnonymous.Set(true);

            await base.NavigationStartedAsync();
        }

        public void TapLogin() => Forward<LoginPage>();

        public void TapRegister() => Forward<RegisterPage>();
    }
}
