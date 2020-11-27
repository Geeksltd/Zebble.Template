using Zebble;
using Zebble.Mvvm;

namespace ViewModel
{
    class LoginPage : FullScreen
    {
        public readonly Bindable<string> Email = new Bindable<string>();
        public readonly Bindable<string> Password = new Bindable<string>();

        public void TapLogin()
        {
            Go<ShoesPage>();
            // Services.Auth.Login(Email.Value, Password.Value);
        }
    }
}
