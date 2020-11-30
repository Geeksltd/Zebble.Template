namespace Domain.Services
{
    using System;

    public class UserSession
    {
        public string AuthToken { get; set; }
        public string Email { get; set; }
        public DateTimeOffset ExpiresAt { get; set; }
    }
}
