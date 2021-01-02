using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleWebAPI.CrossCutting.Configuration;

namespace SimpleWebAPI.Api.Infrastructure.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        private readonly string _tokenHeader = "Bearer ";

        public AuthenticationMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var Requestvalue = context.Request.Path.Value.ToLower();
            if (Requestvalue.Equals("/index.html")
                || Requestvalue.Equals("/swagger/v1/swagger.json")
                || Requestvalue.Equals("/index.html")
                || Requestvalue.EndsWith("login") 
                || Requestvalue.EndsWith("forgotpassword"))
            {
                await _next.Invoke(context);
                return;
            }

            string authorizationHeader = context.Request.Headers["Authorization"];
            var jwtToken = string.Empty;

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                context.Response.StatusCode = 401;
                return;
            }

            if (authorizationHeader.StartsWith(_tokenHeader, StringComparison.OrdinalIgnoreCase))
                jwtToken = authorizationHeader.Substring(_tokenHeader.Length).Trim();

            if (string.IsNullOrEmpty(jwtToken) || jwtToken == "undefined" || jwtToken == "null")
            {
                context.Response.StatusCode = 401;
                return;
            }

            var secret = _appSettings.Secret;

            var principal = GetPrincipal(jwtToken, secret);

            if (principal == null)
            {
                context.Response.StatusCode = 401;
                return;
            }

            context.User = principal;

            await _next.Invoke(context);
        }

        private ClaimsPrincipal GetPrincipal(string token, string secret)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(secret);

                var validationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                return tokenHandler.ValidateToken(token, validationParameters, out _);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder app)
        {
            var result = app.UseMiddleware<AuthenticationMiddleware>();
            return result;
        }
    }
}
