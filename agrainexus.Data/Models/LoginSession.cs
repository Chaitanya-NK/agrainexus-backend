using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agrainexus.Data.Models
{
    public class LoginSession
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? SessionId { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
    }
}
