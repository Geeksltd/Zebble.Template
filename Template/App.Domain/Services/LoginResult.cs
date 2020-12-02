namespace Domain
{
    using System;

    class LoginResult
    {
        public bool Succeeded { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }

        public User User { get; set; }

        public static LoginResult Success(string authToken, string email, DateTimeOffset expiresAt) => new()
        {
            Succeeded = true,
            User = new User
            {
                AuthToken = authToken,
                Email = email,
                ExpiresAt = expiresAt
            }
        };

        public static LoginResult Failure(int code, string message) => new()
        {
            Succeeded = false,
            Code = code,
            Message = message
        };
    }
}
