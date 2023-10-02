using agrainexus.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agrainexus.Business.IServices
{
    public interface IUserService
    {
        public string GetAllUsers();
        public string GetUserById(int? id);
        public string GetUserByEmail(string email);
        public string Register(User user);
        public string UpdateUser(User user);
        public string DeleteUser(int id);
        public string UserLogin(UserDto userDto);
        public string ForgotPassword(UserDto userDto);
    }
}
