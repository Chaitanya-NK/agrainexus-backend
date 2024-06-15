using agrainexus.Business.IServices;
using agrainexus.Data.IRepositories;
using agrainexus.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agrainexus.Business.Services
{
    public class LoginSessionService : ILoginSessionService
    {
        private readonly ILoginSessionRepository _loginSessionRepository;

        public LoginSessionService(ILoginSessionRepository loginSessionRepository)
        {
            _loginSessionRepository = loginSessionRepository;
        }
        public void Create(string userName, DateTime loginTime)
        {
            _loginSessionRepository.Create(userName, loginTime);
        }
        public void LogoutSession(string sessionId, DateTime logoutTime)
        {
            _loginSessionRepository.Update(sessionId, logoutTime);
        }
        public int GetActiveLoginCount()
        {
            return _loginSessionRepository.GetActiveLoginCount();
        }
        public string GetSessionIdByUserName(string userName)
        {
            return _loginSessionRepository.GetSessionIdByUserName(userName);
        }
    }
}
