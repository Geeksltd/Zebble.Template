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
            Dialog.Alert("Sign up is not implemented");

            if (Dialog.Confirm("Would you like to see some shoes instead?"))
                MyShoes();
        }

        public void MyShoes() => Forward<ShoesPage>();
    }
}
