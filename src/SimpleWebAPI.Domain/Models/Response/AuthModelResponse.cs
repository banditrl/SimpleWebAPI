using System.Collections.Generic;

namespace SimpleWebAPI.Domain.Models.Response
{
    public class AuthModelResponse
    {
        public string Message { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; }

        public string Token { get; set; }
    }
}