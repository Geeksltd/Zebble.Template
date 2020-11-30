namespace Domain.Entities
{
    using System;

    public class User
    {
        public string AuthToken { get; set; }
        public string Email { get; set; }
        public DateTimeOffset ExpiresAt { get; set; }
    }
}
