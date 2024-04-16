using agrainexus.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agrainexus.Data.IRepositories
{
    public interface IFarmRepository
    {
        public string AddFarmDetails(Farm farm);
        public List<Farm> GetFarmDetailsByUserId(int userId);
        public string UpdateFarmData(Farm farm);
        public string DeleteFarm(int farmId);
    }
}
