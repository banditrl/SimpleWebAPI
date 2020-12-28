using System.Collections.Generic;
using SimpleWebAPI.Domain.Models;

namespace SimpleWebAPI.Domain.Interfaces
{
	public interface IUserService
	{
		UserModel Authenticate(UserModel model, string ipAddress);

		UserModel RefreshToken(string token, string ipAddress);

		bool RevokeToken(string token, string ipAddress);

		IEnumerable<UserModel> GetAll();

		UserModel GetById(int id);
	}
}
