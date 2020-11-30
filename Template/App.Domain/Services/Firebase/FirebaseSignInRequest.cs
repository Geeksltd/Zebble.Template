namespace Domain.Services.Firebase
{
    class FirebaseSignInRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ReturnSecureToken { get; set; } = true;

        public static FirebaseSignInRequest Create(string email, string password) => new()
        {
            Email = email,
            Password = password
        };
    }
}
