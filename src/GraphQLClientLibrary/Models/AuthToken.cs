using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLClientLibrary.Models
{
    public class AuthTokenRequest
    {
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
    }

    public class AuthTokenResponse
    {
        public string Access_Token { get; set; }
    }
}
