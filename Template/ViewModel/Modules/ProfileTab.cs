namespace ViewModel
{
    using Domain;
    using System.Threading.Tasks;
    using Zebble;
    using Zebble.Mvvm;

    class ProfileTab : ViewModel
    {
        readonly IAuthService AuthService;

        public readonly Bindable<string> LoggedInUserEmail = new("joe@doe.com");

        public ProfileTab()
        {
            AuthService = new FirebaseAuthService();

            AuthService.GetUser().ContinueWith(x => LoggedInUserEmail.Value = x.Result.Email);
        }

        public async Task TapLogout()
        {
            await AuthService.Logout();

            Go<WelcomePage>(PageTransition.SlideBack);
        }
    }
}
