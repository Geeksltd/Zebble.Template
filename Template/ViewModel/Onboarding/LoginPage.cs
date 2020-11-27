using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
            Go<ShoesPage>();
            // Services.Auth.Login(Email.Value, Password.Value);
        }
    }
}
