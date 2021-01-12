namespace ViewModel
{
    using System.Threading.Tasks;
    using Zebble;
    using Zebble.Mvvm;
    using Olive;

    class LoginPage : FullScreen
    {
        public readonly Bindable<string> Email = new Bindable<string>();
        public readonly Bindable<string> Password = new Bindable<string>();

        public async Task TapLogin()
        {
            var result = await FirebaseAuth.Current.Login(Email.Value, Password.Value);

            if (result.Succeeded)
                Go<WelcomePage>();
            else
                Dialog.Alert($"Login failed: {result.Message} ({result.Code})");
        }

        public void TapRegister() => Forward<RegisterPage>();
    }
}