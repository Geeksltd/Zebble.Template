namespace ViewModel
{
    using System.Threading.Tasks;
    using Zebble;
    using Zebble.Mvvm;

    class WelcomePage : FullScreen
    {
        public readonly Bindable<string> SampleProperty = new Bindable<string>("Hello world!");
        public Bindable<bool> IsBusy = new Bindable<bool>(false);
        public Bindable<bool> IsAnonymous = new Bindable<bool>(false);
        public readonly Bindable<string> LoggedInUserEmail = new("...");

        protected async override Task NavigationStartedAsync()
        {
            IsBusy.Set(true);

            LoggedInUserEmail.Set("...");
            IsAnonymous.Set(false);

            var isValid = await FirebaseAuth.Current.RefreshTokenExpiry();

            if (isValid)
            {
                var user = await FirebaseAuth.Current.GetUser();

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

            await FirebaseAuth.Current.Logout();

            Go<LoginPage>(PageTransition.SlideBack);

            IsBusy.Set(false);
        }
    }
}
