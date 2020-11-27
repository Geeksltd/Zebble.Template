namespace ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;

    public class WelcomePage : Zebble.Mvvm.FullScreen
    {
        public readonly Bindable<string> SampleProperty = new Bindable<string>("Hello world!");

        public void LoginTapped()
        {
            Forward<LoginPage>();
        }

        public void SignUpTapped()
        {
            Dialog.Alert("It's not implemented yet!");

            if (Dialog.Confirm("Would you like to log in instead?"))
                LoginTapped();
        }
    }
}
