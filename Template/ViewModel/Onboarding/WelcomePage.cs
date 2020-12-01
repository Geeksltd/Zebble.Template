namespace ViewModel
{
    using Zebble;
    using Zebble.Mvvm;

    public class WelcomePage : FullScreen
    {
        public readonly Bindable<string> SampleProperty = new Bindable<string>("Hellow world!");

        public void TapLogin() => Forward<LoginPage>();

        public void TapSignUp()
        {
            Dialog.Alert("It's not implemented yet!");

            if (Dialog.Confirm("Would you like to log in instead?"))
                TapLogin();
        }
    }
}
