using Domain;
using Domain.Models;
using Olive;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zebble.Mvvm;

namespace ViewModel
{
    public class Login : FullScreen
    {
        public Bindable<string> Email = new();
        public Bindable<string> Password = new();

        protected override async Task NavigationStartedAsync()
        {
            await base.NavigationStartedAsync();
            ResetFeilds();
        }
        public async Task OnLoginTapped()
        {
            if (Email.Value.IsEmpty())
            {
                ShowPopUp<WarningAlert>(x => x.Message.Value = "Please enter the email you used to register.");
                return;
            }
            if (!Email.Value.IsValidEmailAddress())
            {
                ShowPopUp<WarningAlert>(x => x.Message.Value = "Please enter the email you used to register.");
                return;
            }

            if (Password.Value.IsEmpty())
            {
                ShowPopUp<WarningAlert>(x => x.Message.Value = "Please enter the email you used to register.");
                return;
            }

            var authResponse = await Api.Authentication.AuthenticateWithCredentials(Email, Password);
            if (authResponse.Status == AuthenticationResponseStatus.Successful)
                Forward<Categories>();
            else if (authResponse.Status == AuthenticationResponseStatus.InvalidUsernameOrPassword)
                ShowPopUp<WarningAlert>(x => x.Message.Value = "Email or password is not valid.");
            else
                ShowPopUp<WarningAlert>(x => x.Message.Value = "An error is occured.");

        }
        public Task OnContactUsTapped()
        {
#if ANDROID || IOS || UWP
            return Zebble.Device.OS.OpenBrowser("https://www.geeks.ltd.uk/contact-us/contact-us-details");
#else
            return Task.CompletedTask;
#endif

        }

        void ResetFeilds()
        {
            Email.Set(string.Empty);
            Password.Set(string.Empty);
        }
    }
}
