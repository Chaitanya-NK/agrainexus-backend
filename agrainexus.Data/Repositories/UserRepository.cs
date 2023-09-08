using agrainexus.Data.IRepositories;
using agrainexus.Data.Models;
using agrainexus.Static;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agrainexus.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            string? connectionString = _configuration.GetConnectionString(StaticStrings.DBString);
            _connection = new SqlConnection(connectionString);
        }
        public string Register(User user)
        {
            try
            {
                    using (SqlCommand sqlCommand = new SqlCommand("Register", _connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.AddWithValue("@UserName", user.UserName);
                        sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                        sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                        sqlCommand.Parameters.AddWithValue("@State", user.State);
                        sqlCommand.Parameters.AddWithValue("@District", user.District);

                        _connection.Open();
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        _connection.Close();

                        if (rowsAffected > 0)
                        {
                            string? message = "User Registration successfully";
                            return message;
                        }
                        else
                        {
                            string? message = "User Registration failed";
                            return message;
                        }
                    }
                
            }
            catch (Exception ex)
            {
                string? message = "User Registration failed" + ex.Message;
                return message;
            }
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
