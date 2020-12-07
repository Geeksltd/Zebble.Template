namespace ViewModel
{
    using Domain;
    using System.Threading.Tasks;
    using UI.Utils;
    using Zebble;
    using Zebble.Mvvm;

    class WelcomePage : FullScreen
    {
        readonly IAuthService AuthService;

        public readonly Bindable<string> SampleProperty = new Bindable<string>("Hellow world!");
        public WaitingAwareBindable IsBusy = new WaitingAwareBindable(false);
        public Bindable<bool> IsAnonymous = new Bindable<bool>(false);

        public WelcomePage() => AuthService = new FirebaseAuthService();

        protected async override Task NavigationStartedAsync()
        {
            await Task.Delay(50);

            using (await IsBusy.SetAsync(true))
            {
                var isValid = await AuthService.ValidateUserValidity();

                if (isValid)
                    Go<ShoesPage>();
                else
                    IsAnonymous.Set(true);
            }

            await base.NavigationStartedAsync();
        }

        public void TapLogin() => Forward<LoginPage>();

        public void TapRegister() => Forward<RegisterPage>();
    }
}
