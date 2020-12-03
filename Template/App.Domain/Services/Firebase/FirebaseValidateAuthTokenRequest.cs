namespace Domain
{
    class FirebaseValidateAuthTokenRequest
    {
        public string AuthToken { get; set; }

        public static FirebaseValidateAuthTokenRequest Create(string authToken) => new()
        {
            AuthToken = authToken
        };
    }
}
