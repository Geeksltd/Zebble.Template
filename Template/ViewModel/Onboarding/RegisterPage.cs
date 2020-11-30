namespace ViewModel
{
    using System.Threading.Tasks;
    using Zebble;
    using Domain.Services;
    using Domain.Services.Firebase;

    public class RegisterPage : Zebble.Mvvm.FullScreen
    {
        readonly IAuthService AuthService;

        public readonly Bindable<string> Email = new("");
        public readonly Bindable<string> Password = new("");

        public RegisterPage()
        {
            AuthService = new FirebaseAuthService();
        }

        public async Task RegisterTapped()
        {
            var result = await AuthService.Register(Email.Value, Password.Value);

            if (result.Succeeded)
                Go<HomePage>();
            else
                Dialog.Alert($"Register failed: {result.Message} ({result.Code})");
        }

        public void LoginTapped() => Forward<LoginPage>();
    }
}
