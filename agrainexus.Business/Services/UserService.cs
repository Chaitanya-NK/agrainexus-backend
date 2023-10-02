using agrainexus.Business.IServices;
using agrainexus.Data.IRepositories;
using agrainexus.Data.Models;
using agrainexus.TokenGeneration.TokenInterface;
using Newtonsoft.Json.Linq;
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
        private readonly IToken _token;
        public UserService(IUserRepository iUserRepository, IToken iToken)
        {
            _userRepository = iUserRepository;
            _token = iToken;
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
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            var result = _userRepository.UserLogin(userDto);

            if (result != null)
            {
                var tokenModel = new TokenModel
                {
                    Id = result.Id.ToString(),
                    UserName = result.UserName,
                    Email = result.Email
                };

                string token = _token.CreateToken(tokenModel);
                return token;
            }
            else
            {
                throw new UnauthorizedAccessException("Invalid User");
            }
        }
    }
}
