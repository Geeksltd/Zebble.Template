namespace ViewModel
{
    using System.Threading.Tasks;
    using Zebble;
    using Domain;
    using Zebble.Mvvm;
    using UI.Utils;

    class LoginPage : FullScreen
    {
        readonly IAuthService AuthService;

        public readonly WaitingAwareBindable IsBusy = new WaitingAwareBindable(false);
        public readonly Bindable<string> Email = new Bindable<string>();
        public readonly Bindable<string> Password = new Bindable<string>();

        public LoginPage() => AuthService = new FirebaseAuthService();

        public async Task TapLogin()
        {
            using (await IsBusy.SetAsync(true))
            {
                var result = await AuthService.Login(Email.Value, Password.Value);

                if (result.Succeeded)
                    Go<HomePage>();
                else
                    Dialog.Alert($"Login failed: {result.Message} ({result.Code})");
            }
        }

        public void TapRegister() => Forward<RegisterPage>();
    }
}