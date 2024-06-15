using agrainexus.Data.IRepositories;
using agrainexus.Data.Models;
using agrainexus.Static;
using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agrainexus.Data.Repositories
{
    public class OutsideTemperatureRepository : IOutsideTemperatureRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public OutsideTemperatureRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _configuration = configuration;
            string? connectionString = _configuration.GetConnectionString(StaticStrings.DBString);
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        }

        public async Task<double> GetOutsideTemperature()
        {
            try
            {
                HttpResponseMessage responseMessage = await _httpClient.GetAsync("https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/Hyderabad/today?unitGroup=metric&include=current&key=HMEJPQKU3B2TDHDL8TTNAC8ST&contentType=json");
                responseMessage.EnsureSuccessStatusCode();

                OutsideTemperature apiResponse = await responseMessage.Content.ReadAsAsync<OutsideTemperature>();

                return apiResponse.Temperature;
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error while fetching the temperature data" + ex.Message);
                return 0.0;
            }
        }
    }
}
