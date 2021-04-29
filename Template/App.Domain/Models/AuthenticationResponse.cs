using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class AuthenticationResponse
    {
        public string Message { get; set; }
        public AuthenticationResponseStatus Status { get; set; }
        public string Token { get; set; }
    }

    public enum AuthenticationResponseStatus
    {
        Successful = 100,
        UserNotFound = 200,
        InvalidUsernameOrPassword = 201,
        ServerError = 900,
        ApplicationError = 1000
    }
}
