using AutoMapper;
using SimpleWebAPI.Domain.Models.Request;
using SimpleWebAPI.Domain.Models.Response;

namespace SimpleWebAPI.Domain.Interfaces
{
	public interface IAuthService
	{
		AuthModelResponse Authenticate(AuthModelRequest model, string ipAddress);

		AuthModelResponse RefreshToken(string token, string ipAddress);

		bool RevokeToken(string token, string ipAddress);
	}
}
