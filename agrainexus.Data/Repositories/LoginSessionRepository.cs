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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace agrainexus.Data.Repositories
{
    public class LoginSessionRepository : ILoginSessionRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        public LoginSessionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            string? connectionString = _configuration.GetConnectionString(StaticStrings.DBString);
            _connection = new SqlConnection(connectionString);
        }
        public void Create(string userName, DateTime loginTime)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("CreateLoginSession", _connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@UserName", userName);
                    sqlCommand.Parameters.AddWithValue("@LoginTime", loginTime);
                    _connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during creating a login session" + ex.Message);
                throw;
            }
        }

        /*public async Task<Models.LoginSession> GetById(int sessionId)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("GetLoginSessionById", _connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", sessionId);

                    using (var reader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            return MapLoginSessionFromReader(reader);
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while extracting the Session information using Id", ex.Message);
                throw;
            }
        }*/

        public void Update(string sessionId, DateTime logoutTime)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("UpdateLoginSession", _connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@SessionId", sessionId);
                    sqlCommand.Parameters.AddWithValue("@LogoutTime", logoutTime);
                    _connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred while updating the login session" + ex.Message);
            }
        }

        public int GetActiveLoginCount()
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("GetActiveLoginCount", _connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    _connection.Open();
                    return (int)sqlCommand.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred while getting the active login count" + ex.Message);
                throw;
            }
        }

        public string GetSessionIdByUserName(string userName)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("GetSessionIdByUserName", _connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserName", userName);
                    _connection.Open();
                    return (string)sqlCommand.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                return ("An error occurred while getting the session id using user name" + ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        /*private Models.LoginSession MapLoginSessionFromReader(SqlDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return null;
            }

            Models.LoginSession loginSession = new Models.LoginSession();

            while (reader.Read())
            {
                if (reader["Id"] != DBNull.Value)
                {
                    loginSession.Id = (int)reader["Id"];
                }

                if (reader["UserId"] != DBNull.Value)
                {
                    loginSession.UserId = (int)reader["UserId"];
                }

                if (reader["SessionId"] != DBNull.Value)
                {
                    loginSession.SessionId = (string)reader["SessionId"];
                }

                if (reader["LoginTime"] != DBNull.Value)
                {
                    loginSession.LoginTime = (DateTime)reader["LoginTime"];
                }

                if (reader["LogoutTime"] != DBNull.Value)
                {
                    loginSession.LogoutTime = (DateTime)reader["LogoutTime"];
                }
            }

            return loginSession;
        }*/
    }
}
