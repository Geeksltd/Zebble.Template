namespace Domain.Services.Firebase
{
    using Domain.Entities;
    using Domain.Extensions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Zebble.Device;

    class FirebaseAuthService : IAuthService
    {
        public async Task<bool> IsAuthenticated() => await GetUser() != null;

        public async Task<bool> IsAnonymous() => !await IsAuthenticated();

        public async Task<RegisterResult> Register(string email, string password)
        {
            var request = FirebaseSignUpRequest.Create(email, password);

            var response = await FirebaseAuthApis.SignUp(request);

            if (response.Error != null)
                return RegisterResult.Failure(response.Error.Code, response.Error.Message);

            var result = RegisterResult.Success(response.IdToken, response.Email, response.ExpiresIn.ToUnixOffset());

            await PersistUser(result.User);

            return result;
        }

        public async Task<LoginResult> Login(string email, string password)
        {
            var request = FirebaseSignInRequest.Create(email, password);

            var response = await FirebaseAuthApis.SignIn(request);

            if (response.Error != null)
                return LoginResult.Failure(response.Error.Code, response.Error.Message);

            var result = LoginResult.Success(response.IdToken, response.Email, response.ExpiresIn.ToUnixOffset());

            await PersistUser(result.User);

            return result;
        }

        public async Task<User> GetUser()
        {
            return await LoadUser();
        }

        public async Task Logout()
        {
            await PersistUser(null);
        }

        private async Task PersistUser(User result)
        {
            await GetUserFile().WriteAllTextAsync(result.ToJson());
        }

        private async Task<User> LoadUser()
        {
            return (await GetUserFile().ReadAllTextAsync()).FromJson<User>();
        }

        private FileInfo GetUserFile() => IO.File("User.json");
    }
}
