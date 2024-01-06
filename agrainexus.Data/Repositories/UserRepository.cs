using agrainexus.Data.IRepositories;
using agrainexus.Data.Models;
using agrainexus.Static;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
                _connection.Close();
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

        public string GetToken(string userName)
        {
            using (SqlCommand sqlCommand = new SqlCommand("TokenDetails", _connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue(StaticUser.UserName, userName);
                _connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                _connection.Close();

                if (dt.Rows.Count > 0)
                {
                    return JsonConvert.SerializeObject(dt);
                }
                else
                {
                    return "Employee not found.";
                }
            }
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

        public User UserLogin(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }
            using (SqlCommand sqlCommand = new SqlCommand("Login", _connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@UserName", userDto.UserName);
                sqlCommand.Parameters.AddWithValue("@Password", userDto.Password);

                using SqlDataAdapter sqlDataAdapter = new(sqlCommand);
                var dataset = new DataSet();
                sqlDataAdapter.Fill(dataset);

                if(dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
                {
                    var user = new User
                    {
                        Id = (int)dataset.Tables[0].Rows[0]["Id"],
                        UserName = dataset.Tables[0].Rows[0]["UserName"].ToString(),
                        Email = dataset.Tables[0].Rows[0]["Email"].ToString()
                    };

                    return user;
                }
                else
                {
                    return null;
                }
             }
        }
    }
}
