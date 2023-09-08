using agrainexus.Data.Models;
using agrainexus.Static;
using agrainexus.TokenGeneration.TokenInterface;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace agrainexus.TokenGeneration.TokenImplementation
{
    public class Token : IToken
    {
        public string CreateToken(TokenModel tokenModel)
        {
            if(tokenModel == null)
            {
                throw new ArgumentNullException(nameof(tokenModel));
            }

            var claims = new List<Claim>
            {
                new Claim(StaticUser.Id, tokenModel.Id),
                new Claim(StaticUser.UserName, tokenModel.UserName),
                new Claim(StaticUser.Email, tokenModel.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(StaticToken.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var utcNow = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
            var token = new JwtSecurityToken(StaticToken.JwtIssuer,
                                             StaticToken.JwtAudience,
                                             claims,
                                             expires: DateTime.Now.AddMinutes(StaticToken.JwtTokenExpiryMinutes),
                                             signingCredentials: credentials,
                                             notBefore: utcNow
                                            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public TokenModel ReadToken(string token)
        {
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(StaticToken.JwtKey));
                var handler = new JwtSecurityTokenHandler();
                var validations = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = true,
                    ValidIssuer = StaticToken.JwtIssuer,
                    ValidateAudience = true,
                    ValidAudience = StaticToken.JwtAudience,
                };

                handler.InboundClaimTypeMap.Clear();
                SecurityToken securityToken;
                var identity = handler.ValidateToken(token, validations, out securityToken).Identity as ClaimsIdentity;
                if(identity == null || identity.Claims == null)
                {
                    return null;
                }
                var user = new TokenModel();
                foreach(var item in identity.Claims)
                {
                    switch(item.Type)
                    {
                        case StaticUser.Id:
                            user.Id = item.Value;
                            break;
                        case StaticUser.UserName:
                            user.UserName = item.Value;
                            break;
                        case StaticUser.Email:
                            user.Email = item.Value;
                            break;
                    }
                }
                return user;
            }
            catch
            {
                return null;
            }
        }
    }
}
