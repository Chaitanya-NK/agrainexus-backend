using agrainexus.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agrainexus.Business.IServices
{
    public interface IFarmService
    {
        public string AddFarmDetails(Farm farm);
        public List<Farm> GetFarmDetailsByUserId(int userId);
        public string UpdateFarmData(Farm farm);
    }
}
