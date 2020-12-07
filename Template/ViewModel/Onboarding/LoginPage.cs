namespace ViewModel
{
    using System.Threading.Tasks;
    using Zebble;
    using Domain;
    using Zebble.Mvvm;

    class LoginPage : FullScreen
    {
        readonly IAuthService AuthService;

        public readonly Bindable<string> Email = new Bindable<string>();
        public readonly Bindable<string> Password = new Bindable<string>();

        public LoginPage() => AuthService = new FirebaseAuthService();

        public async Task TapLogin()
        {
            var result = await AuthService.Login(Email.Value, Password.Value);

            if (result.Succeeded)
                Go<WelcomePage>();
            else
                Dialog.Alert($"Login failed: {result.Message} ({result.Code})");
        }

        public void TapRegister() => Forward<RegisterPage>();
    }
}