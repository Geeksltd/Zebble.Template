namespace ViewModel
{
    using System.Threading.Tasks;
    using Zebble;
    using Domain;
    using Zebble.Mvvm;

    class RegisterPage : FullScreen
    {
        readonly IAuthService AuthService;

        public readonly Bindable<string> Email = new Bindable<string>();
        public readonly Bindable<string> Password = new Bindable<string>();

        public RegisterPage() => AuthService = new FirebaseAuthService();

        public async Task TapRegister()
        {
            var result = await AuthService.Register(Email.Value, Password.Value);

            if (result.Succeeded)
                Go<ShoesPage>();
            else
                Dialog.Alert($"Register failed: {result.Message} ({result.Code})");
        }

        public void TapLogin() => Forward<LoginPage>();
    }
}
