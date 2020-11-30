namespace Domain.Services.Firebase
{
    using Domain.Extensions;
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble.Device;

    static class FirebaseAuthApis
    {
        const string WEB_API_TOKEN = "AIzaSyCqHqaAXz2cZs0ZL_ACyQQmATi6rpcXPIM";
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

            using var client = CreateClient();

            var uri = CreateRequestUri(path);
            var payload = new StringContent(request.ToJson(), encoding, "text/json");

            try
            {
                var message = await client.PostAsync(uri, payload);

                return encoding.GetString(await message.Content.ReadAsByteArrayAsync());
            }
            catch (Exception)
            {
                throw;
            }
        }

        static HttpClient CreateClient() => Network.HttpClient(BASE_ADDRESS, TimeSpan.FromSeconds(30));

        static string CreateRequestUri(string path) => REQUEST_PATH.FormatWith(path, WEB_API_TOKEN);
    }
}
