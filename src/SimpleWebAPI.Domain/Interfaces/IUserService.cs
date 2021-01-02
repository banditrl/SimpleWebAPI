using System.Collections.Generic;
using SimpleWebAPI.Domain.Models;

namespace SimpleWebAPI.Domain.Interfaces
{
	public interface IUserService
	{
		IEnumerable<UserModel> GetAll();

		UserModel GetById(int id);
	}
}
