using agrainexus.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agrainexus.Business.IServices
{
    public interface ILoginSessionService
    {
        void Create(string userName, DateTime loginTime);
        void LogoutSession(string userName, DateTime logoutTime);
        int GetActiveLoginCount();
        public string GetSessionIdByUserName(string userName);
    }
}
