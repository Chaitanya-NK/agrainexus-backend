using agrainexus.Business.IServices;
using agrainexus.Data.IRepositories;
using agrainexus.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agrainexus.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository iUserRepository)
        {
            _userRepository = iUserRepository;
        }
        public string DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public string ForgotPassword(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public string GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public string GetToken(int id)
        {
            throw new NotImplementedException();
        }

        public string GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public string GetUserById(int? id)
        {
            throw new NotImplementedException();
        }

        public string Register(User user)
        {
            return _userRepository.Register(user);
        }

        public string UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public string UserLogin(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
