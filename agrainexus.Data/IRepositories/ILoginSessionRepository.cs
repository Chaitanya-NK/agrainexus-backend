using agrainexus.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agrainexus.Data.IRepositories
{
    public interface ILoginSessionRepository
    {
        void Create(string userName, DateTime loginTime);
        void Update(string sessionId, DateTime logoutTime);
        int GetActiveLoginCount();
        public string GetSessionIdByUserName(string userName);

    }
}
