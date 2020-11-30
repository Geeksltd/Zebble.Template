namespace ViewModel
{
    using Domain.Services;
    using Domain.Services.Firebase;
    using System.Threading.Tasks;
    using Zebble;

    public class HomePage : Zebble.Mvvm.FullScreen
    {
        readonly IAuthService AuthService;

        public readonly Bindable<string> LoggedInUserEmail = new("joe@doe.com");

        public HomePage()
        {
            AuthService = new FirebaseAuthService();
        }

        protected override async Task NavigationStartedAsync()
        {
            var loggedInUser = await AuthService.GetLoggedInUser();

            LoggedInUserEmail.Value = loggedInUser.Email;

            await base.NavigationStartedAsync();
        }

        public async Task LogoutTapped()
        {
            await AuthService.Logout();

            Go<WelcomePage>(PageTransition.SlideBack);
        }
    }
}
