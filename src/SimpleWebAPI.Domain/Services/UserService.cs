using System.Collections.Generic;
using SimpleWebAPI.Domain.Interfaces;
using SimpleWebAPI.Domain.Models;

namespace SimpleWebAPI.Domain.Services
{
    public class UserService : IUserService
    {
        //private DataContext _context;

        public UserService(
           // DataContext context
           )
        {
            //_context = context;
        }

        public IEnumerable<UserModel> GetAll()
        {
            return new List<UserModel>();
            //return _context.Users;
        }

        public UserModel GetById(int id)
        {
            return new UserModel();
            //return _context.Users.Find(id);
        }
	}
}
