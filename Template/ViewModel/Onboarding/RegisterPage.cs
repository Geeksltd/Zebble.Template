namespace ViewModel
{
    using System.Threading.Tasks;
    using Zebble;
    using Zebble.Mvvm;
    using Olive;

    class RegisterPage : FullScreen
    {
        public readonly Bindable<string> Email = new Bindable<string>();
        public readonly Bindable<string> Password = new Bindable<string>();

        public async Task TapRegister()
        {
            var result = await FirebaseAuth.Current.Register(Email.Value, Password.Value);

            if (result.Succeeded)
                Go<WelcomePage>();
            else
                Dialog.Alert($"Register failed: {result.Message} ({result.Code})");
        }

        public void TapLogin() => Forward<LoginPage>();
    }
}
