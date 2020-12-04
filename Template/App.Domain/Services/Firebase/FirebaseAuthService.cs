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
        public async Task<bool> ValidateUserValidity()
        {
            await Task.Delay(2000);

            var user = await GetUser();

            if (user != null)
            {
                if (user.ExpiresAt > LocalTime.Now)
                {
                    await Logout();
                    return false;
                }

                var request = FirebaseValidateAuthTokenRequest.Create(user.AuthToken);

                var response = await FirebaseAuthApis.ValidateAuthToken(request);

                if (response.Error != null)
                    return false;

                return response.IsValid;
            }

            return false;
        }

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
            await Task.Delay(2000);

            await GetUserFile().WriteAllTextAsync(result.ToJson());
        }

        private async Task<User> LoadUser()
        {
            await Task.Delay(1000);

            var userFile = GetUserFile();

            if (userFile.Exists())
                return (await userFile.ReadAllTextAsync()).FromJson<User>();

            return null;
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

            return await Post<FirebaseSignUpResponse>(path, request);
        }

        public static async Task<FirebaseSignInResponse> SignIn(FirebaseSignInRequest request)
        {
            var path = "accounts:signInWithPassword";

            return await Post<FirebaseSignInResponse>(path, request);
        }

        public static async Task<FirebaseValidateAuthTokenResponse> ValidateAuthToken(FirebaseValidateAuthTokenRequest request)
        {
            return new FirebaseValidateAuthTokenResponse
            {
                IsValid = request.AuthToken.HasValue()
            };
        }

        static async Task<T> Post<T>(string path, object request, Encoding encoding = null) where T : FirebaseResponseBase, new()
        {
            encoding ??= Encoding.UTF8;

            try
            {
                var client = CreateClient();

                var uri = CreateRequestUri(path);
                var payload = new StringContent(request.ToJson(), encoding, "text/json");

                var message = await client.PostAsync(uri, payload);

                return encoding.GetString(await message.Content.ReadAsByteArrayAsync()).FromJson<T>();
            }
            catch (Exception)
            {
                return CreateDefault<T>();
            }
        }

        private static T CreateDefault<T>() where T : FirebaseResponseBase, new()
        {
            return new T
            {
                Error = new FirebaseError
                {
                    Code = -1,
                    Message = "Can't connect to Firebase Auth APIS"
                }
            };
        }

        //static HttpClient CreateClient() => Network.HttpClient(BASE_ADDRESS, TimeSpan.FromSeconds(30));
        static HttpClient CreateClient() => new() { BaseAddress = new Uri(BASE_ADDRESS), Timeout = TimeSpan.FromSeconds(30) };

        static string CreateRequestUri(string path) => REQUEST_PATH.FormatWith(path, WEB_API_TOKEN);
    }
}
