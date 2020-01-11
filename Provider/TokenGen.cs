using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LuciaTech.Helper.Provider
{
    public class TokenGen
    {
        public static string GenerateTokenJWT(string tokenString, string JWTISSUER, string JWTKEY, string role = "user")
        {
            var claims = new[]
               {
                  new Claim(ClaimTypes.Name , tokenString),
                  new Claim(ClaimTypes.Role , role),
                  new Claim(JwtRegisteredClaimNames.Sub, tokenString),
                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTKEY));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(JWTISSUER,
              JWTISSUER,
              claims,
              expires: DateTime.Now.AddDays(1),
              signingCredentials: creds);
            var showTken = new JwtSecurityTokenHandler().WriteToken(token);

            return $"Bearer {showTken}";
        }
    }
}
