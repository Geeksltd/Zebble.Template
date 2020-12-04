namespace ViewModel
{
    using System.Threading.Tasks;
    using Zebble;
    using Domain;
    using Zebble.Mvvm;

    class LoginPage : FullScreen
    {
        readonly IAuthService AuthService;

        public readonly Bindable<bool> IsBusy = new(false);
        public readonly Bindable<string> Email = new("");
        public readonly Bindable<string> Password = new("");

        public LoginPage()
        {
            AuthService = new FirebaseAuthService();
        }

        public async Task TapLogin()
        {
            IsBusy.Set(true);

            var result = await AuthService.Login(Email.Value, Password.Value);

            if (result.Succeeded)
                Go<HomePage>();
            else
                Dialog.Alert($"Login failed: {result.Message} ({result.Code})");

            IsBusy.Set(false);
        }

        public void TapRegister() => Forward<RegisterPage>();
    }
}
