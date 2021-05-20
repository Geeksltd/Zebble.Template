using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    interface IAuthenticationApi
    {
        Task<AuthenticationResponse> AuthenticateWithCredentials(string email, string password);
        Task<User> GetCurrentUser();
    }
}
