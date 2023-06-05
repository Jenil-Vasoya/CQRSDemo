using CQRSDemo.Core.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CQRSDemo.Auth
{
    public class JwtTokenHelper
    {
        public string GenerateToken(User user, Jwt jwt)
        {

            
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwt.key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role, user.Role),

            };
            var token = new JwtSecurityToken(jwt.issuer,
                jwt.audience,
                claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }

    public class Jwt
    {
        public string key { get; set; }
        public string issuer { get; set; }
        public string audience { get; set; }
    }

}
