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
    public class FarmRepository : IFarmRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;

        public FarmRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            string? connectionString = _configuration.GetConnectionString(StaticStrings.DBString);
            _connection = new SqlConnection(connectionString);
        }
        public string AddFarmDetails(Farm farm)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("InsertFarmData", _connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Location", farm.Location);
                    sqlCommand.Parameters.AddWithValue("@Crops", farm.Crops);
                    sqlCommand.Parameters.AddWithValue("@Area", farm.Area);
                    sqlCommand.Parameters.AddWithValue("@UserId", farm.UserId);

                    _connection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    _connection.Close();

                    if (rowsAffected > 0)
                    {
                        string? message = "Farm added successfully";
                        return message;
                    }
                    else
                    {
                        string? message = "Farm adding failed";
                        return message;
                    }
                }
            }
            catch(Exception ex)
            {
                string? message = "Farm adding failed" + ex.Message;
                return message;
            }
        }
    }
}
