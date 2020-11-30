namespace Domain.Services
{
    using System;

    public class RegisterResult
    {
        public bool Succeeded { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }

        public UserSession Session { get; set; }

        public static RegisterResult Success(string authToken, string email, DateTimeOffset expiresAt) => new()
        {
            Succeeded = true,
            Session = new UserSession
            {
                AuthToken = authToken,
                Email = email,
                ExpiresAt = expiresAt
            }
        };

        public static RegisterResult Failure(int code, string message) => new()
        {
            Succeeded = false,
            Code = code,
            Message = message
        };
    }
}
