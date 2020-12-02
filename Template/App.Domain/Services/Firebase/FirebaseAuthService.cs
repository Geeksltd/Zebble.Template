namespace Domain
{
    using Domain.Extensions;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Text;
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

    static class FirebaseAuthApis
    {
        const string WEB_API_TOKEN = "AIzaSyByD-QhNGhHYUz0Dr-SUy4AkaQbJ3fvrtE";
        const string BASE_ADDRESS = "https://identitytoolkit.googleapis.com/";
        const string REQUEST_PATH = "/v1/{0}?key={1}";

        public static async Task<FirebaseSignUpResponse> SignUp(FirebaseSignUpRequest request)
        {
            var path = "accounts:signUp";

            var response = await Post(path, request);

            return response.FromJson<FirebaseSignUpResponse>();
        }

        public static async Task<FirebaseSignInResponse> SignIn(FirebaseSignInRequest request)
        {
            var path = "accounts:signInWithPassword";

            var response = await Post(path, request);

            return response.FromJson<FirebaseSignInResponse>();
        }

        static async Task<string> Post(string path, object request, Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;

            try
            {
                var client = CreateClient();

                var uri = CreateRequestUri(path);
                var payload = new StringContent(request.ToJson(), encoding, "text/json");

                var message = await client.PostAsync(uri, payload);

                return encoding.GetString(await message.Content.ReadAsByteArrayAsync());
            }
            catch (Exception)
            {
                throw;
            }
        }

        //static HttpClient CreateClient() => Network.HttpClient(BASE_ADDRESS, TimeSpan.FromSeconds(30));
        static HttpClient CreateClient() => new() { BaseAddress = new Uri(BASE_ADDRESS), Timeout = TimeSpan.FromSeconds(30) };

        static string CreateRequestUri(string path) => REQUEST_PATH.FormatWith(path, WEB_API_TOKEN);
    }
}
