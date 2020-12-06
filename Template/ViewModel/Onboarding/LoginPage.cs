using Zebble;
using Zebble.Mvvm;

namespace ViewModel
{
    public class LoginPage : FullScreen
    {
        public readonly Bindable<string> Email = new Bindable<string>();
        public readonly Bindable<string> Password = new Bindable<string>();

        public void TapLogin()
        {
            Dialog.Alert("Login is not implemented.");
            Forward<ShoesPage>();
            // Services.Auth.Login(Email.Value, Password.Value);
        }
    }
}