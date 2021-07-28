using System;

namespace GraphQLClientLibrary.Models
{
    public class AuthTokenRequest
    {
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
    }

    public class AuthTokenResponse
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
    }
}
