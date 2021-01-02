namespace SimpleWebAPI.Domain.Models.Request
{
    public class AuthModelRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }
    }
}