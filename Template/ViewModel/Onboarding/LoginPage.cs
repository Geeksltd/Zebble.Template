using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zebble;

namespace ViewModel
{
    public class LoginPage : Zebble.Mvvm.FullScreen
    {
        public readonly Bindable<string> Email = new Bindable<string>();
        public readonly Bindable<string> Password = new Bindable<string>();

        public void LoginTapped()
        {
            // Services.Auth.Login(Email.Value, Password.Value);
        }
    }
}
