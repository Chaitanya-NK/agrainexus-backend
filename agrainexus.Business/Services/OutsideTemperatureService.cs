using agrainexus.Business.IServices;
using agrainexus.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agrainexus.Business.Services
{
    public class OutsideTemperatureService : IOutsideTemperatureService
    {
        private readonly IOutsideTemperatureRepository _outsideTemperatureRepository;

        public OutsideTemperatureService(IOutsideTemperatureRepository outsideTemperatureRepository)
        {
            _outsideTemperatureRepository = outsideTemperatureRepository;
        }

        public Task<double> GetOutsideTemperature()
        {
            return _outsideTemperatureRepository.GetOutsideTemperature();
        }
    }
}
