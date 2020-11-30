namespace Domain.Services.Firebase
{
    using Domain.Extensions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Zebble.Device;

    class FirebaseAuthService : IAuthService
    {
        public async Task<bool> IsAuthenticated() => await GetLoggedInUser() != null;

        public async Task<bool> IsAnonymous() => !await IsAuthenticated();

        public async Task<RegisterResult> Register(string email, string password)
        {
            var request = FirebaseSignUpRequest.Create(email, password);

            var response = await FirebaseAuthApis.SignUp(request);

            if (response.Error != null)
                return RegisterResult.Failure(response.Error.Code, response.Error.Message);

            var result = RegisterResult.Success(response.IdToken, response.Email, response.ExpiresIn.ToUnixOffset());

            await PersistUserSession(result.Session);

            return result;
        }

        public async Task<LoginResult> Login(string email, string password)
        {
            var request = FirebaseSignInRequest.Create(email, password);

            var response = await FirebaseAuthApis.SignIn(request);

            if (response.Error != null)
                return LoginResult.Failure(response.Error.Code, response.Error.Message);

            var result = LoginResult.Success(response.IdToken, response.Email, response.ExpiresIn.ToUnixOffset());

            await PersistUserSession(result.Session);

            return result;
        }

        public async Task<UserSession> GetLoggedInUser()
        {
            return await LoadUserSession();
        }

        public async Task Logout()
        {
            await PersistUserSession(null);
        }

        private async Task PersistUserSession(UserSession result)
        {
            await GetUserSessionFile().WriteAllTextAsync(result.ToJson());
        }

        private async Task<UserSession> LoadUserSession()
        {
            return (await GetUserSessionFile().ReadAllTextAsync()).FromJson<UserSession>();
        }

        private FileInfo GetUserSessionFile() => IO.File("UserSession.json");
    }
}
