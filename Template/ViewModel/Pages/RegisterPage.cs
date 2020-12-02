namespace ViewModel
{
    using System.Threading.Tasks;
    using Zebble;
    using Domain;
    using Zebble.Mvvm;

    class RegisterPage : FullScreen
    {
        readonly IAuthService AuthService;

        public readonly Bindable<string> Email = new("");
        public readonly Bindable<string> Password = new("");

        public RegisterPage()
        {
            AuthService = new FirebaseAuthService();
        }

        public async Task TapRegister()
        {
            var result = await AuthService.Register(Email.Value, Password.Value);

            if (result.Succeeded)
                Go<HomePage>();
            else
                Dialog.Alert($"Register failed: {result.Message} ({result.Code})");
        }

        public void TapLogin() => Forward<LoginPage>();
    }
}
