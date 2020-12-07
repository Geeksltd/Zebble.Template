namespace Domain
{
    using Domain.Extensions;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;
    using Zebble.Device;

    /// <summary>
    /// This implementation is provided to let the users log in to their accounts,
    /// or if they haven't created one before, they'll be able to create a new account.
    /// You, as the developer of this project, need to set up a Google Firebase Auth app in your Console.
    /// To create a new project, open your Firebase console(https://console.firebase.google.com),
    /// click on Add project, enter a name, and then click on the Create Project button.
    /// After that, you've to add an Authentication app to your project.
    /// To do so, on the right side of the project's overview page, head to Develop > Authentication > Get Started.
    /// In this step, you can configure your app to use one or more of the available sign-in providers.
    /// Click on Email/Password, turn the Enable switch on, and click on the Save button.
    /// Next, you have to copy your API token by heading to Project settings > General > Web API Key and then add it to your Config.xml file as follow:
    /// <Firebase.ApiToken value="<YOUR_API_TOKEN>" />
    /// </summary>
    class FirebaseAuthService : IAuthService
    {
        public async Task<bool> ValidateUserValidity()
        {
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
            await GetUserFile().WriteAllTextAsync(result.ToJson());
        }

        private async Task<User> LoadUser()
        {
            var userFile = GetUserFile();

            if (userFile.Exists())
                return (await userFile.ReadAllTextAsync()).FromJson<User>();

            return null;
        }

        private FileInfo GetUserFile() => IO.File("User.json");
    }

    static class FirebaseAuthApis
    {
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
            catch (Exception ex)
            {
                return CreateDefault<T>(ex);
            }
        }

        private static T CreateDefault<T>(Exception ex) where T : FirebaseResponseBase, new()
        {
            return new T
            {
                Error = new FirebaseError
                {
                    Code = -1,
                    Message = $"Can't connect to Firebase Auth APIS. {ex.Message}"
                }
            };
        }

        static HttpClient CreateClient() => Network.HttpClient(BASE_ADDRESS, TimeSpan.FromSeconds(30));

        static string CreateRequestUri(string path)
        {
            var apiToken = Config.Get<string>("Firebase.ApiToken");

            if (!apiToken.HasValue())
                throw new Exception("To use Google Firebase Auth service you'll need to add the provided API token to the Config.xml file. For more info, check out the FirebaseAuthService.");

            return REQUEST_PATH.FormatWith(path, apiToken);
        }
    }
}
