using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using P224FirstApi.DAL.Entities;
using P224FirstApi.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace P224FirstApi.Services
{
    public class JWTService : IJWTService
    {
        public string CreateToken(AppUser appUser, IConfiguration configuration, IList<string> roles)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, appUser.Id),
                new Claim(ClaimTypes.Name, appUser.UserName),
                new Claim("FullName", appUser.FullName),
            };

            foreach (string role in roles)
            {
                //Claim claim = new Claim(ClaimTypes.Role, role);
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("JWT:secretKey").Value));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                issuer: configuration.GetSection("JWT:issuer").Value,
                audience: configuration.GetSection("JWT:audience").Value,
                expires: DateTime.Now.AddDays(3)
                );

            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
