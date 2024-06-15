using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agrainexus.Static
{
    public class StaticStrings
    {
        public const string DBString = "ConnectionString";
    }
    public class StaticToken
    {
        public const string JwtKey = "sdfgbhnjmsdfgbhnjmfdsxdcfvgbhnmgvfcdsxdcfvgbnmmjhgvfcxcvbnmbvcxcvbnm";
        public const string JwtIssuer = "https://www.google.com";
        public const string JwtAudience = "https://www.google.com";
        public const int JwtTokenExpiryMinutes = 1000;
    }

    public class StaticUser
    {
        public const string Id = "Id";
        public const string UserName = "UserName";
        public const string Email = "Email";
        public const string Password = "Password";
        public const string State = "State";
        public const string District = "District";
    }

    public class LoginSession
    {
        public const string Id = "Id";
        public const string UserId = "UserId";
        public const string SessionId = "SessionId";
        public const string LoginTime = "LoginTime";
        public const string LogoutTime = "LogoutTime";
    }

    public class StaticLogin
    {
        public const string InvalidUser = "Wrong Credentials";
    }
}
