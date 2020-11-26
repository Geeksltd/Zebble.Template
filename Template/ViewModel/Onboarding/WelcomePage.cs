using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zebble;

namespace ViewModel
{
    public class WelcomePage : Zebble.Mvvm.FullScreen
    {
        public readonly Bindable<string> SampleProperty = new Bindable<string>("Hellow world!");

        public void LoginTapped()
        {
            Forward<LoginPage>();
        }

        public void SignUpTapped()
        {
            // Go<RegisterPage>();
        }
    }
}
