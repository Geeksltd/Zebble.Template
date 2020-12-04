﻿namespace ViewModel
{
    using System.Threading.Tasks;
    using Zebble;
    using Domain;
    using Zebble.Mvvm;
    using UI.Utils;

    class RegisterPage : FullScreen
    {
        readonly IAuthService AuthService;

        public readonly WaitingAwareBindable IsBusy = new(false);
        public readonly Bindable<string> Email = new("");
        public readonly Bindable<string> Password = new("");

        public RegisterPage()
        {
            AuthService = new FirebaseAuthService();
        }

        public async Task TapRegister()
        {
            using (await IsBusy.SetAsync(true))
            {
                var result = await AuthService.Register(Email.Value, Password.Value);

                if (result.Succeeded)
                    Go<HomePage>();
                else
                    Dialog.Alert($"Register failed: {result.Message} ({result.Code})");
            }
        }

        public void TapLogin() => Forward<LoginPage>();
    }
}
