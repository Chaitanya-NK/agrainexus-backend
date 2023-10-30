using agrainexus.Business.IServices;
using agrainexus.Data.IRepositories;
using agrainexus.Data.Models;
using agrainexus.TokenGeneration.TokenInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agrainexus.Business.Services
{
    public class FarmService : IFarmService
    {
        private readonly IFarmRepository _farmRepository;
        private readonly IToken _token;
        public FarmService(IFarmRepository iFarmRepository, IToken iToken)
        {
            _farmRepository = iFarmRepository;
            _token = iToken;
        }
        public string AddFarmDetails(Farm farm)
        {
            return _farmRepository.AddFarmDetails(farm);
        }

        public List<Farm> GetFarmDetailsByUserId(int userId)
        {
            return _farmRepository.GetFarmDetailsByUserId(userId);
        }
    }
}
