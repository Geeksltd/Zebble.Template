using Domain.Models;
using Olive;
using System;
using System.Threading.Tasks;
using Zebble;

namespace Domain
{
    public class AuthenticationApi : BaseApi, IAuthenticationApi
    {
        private string baseApi = "https://test.co/api/v1/coffee-drinks";

        public Task<AuthenticationResponse> AuthenticateWithCredentials(string email, string password)
        {
            return Post<AuthenticationResponse>($"{baseApi}/auth", new { email = email, password = password });
        }

        public Task<User> GetCurrentUser()
        {
            return Get<User>($"{baseApi}");
        }

    }
}
