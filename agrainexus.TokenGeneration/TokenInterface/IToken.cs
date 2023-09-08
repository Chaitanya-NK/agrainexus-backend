using agrainexus.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agrainexus.TokenGeneration.TokenInterface
{
    public interface IToken
    {
        public string CreateToken(TokenModel tokenModel);
        public TokenModel ReadToken(string token);
    }
}
