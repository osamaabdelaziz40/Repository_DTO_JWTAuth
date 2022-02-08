using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PRJ.Utility;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.API.JWT
{
    public static class JWT
    {
        public static string GenerateJwtToken(SessionDTO dto, IConfiguration configuration)
        {
            string role = string.Empty;
            if (dto.RoleId == Convert.ToInt32(RoleEnums.Admin))
                role = RoleStrings.Admin;
            else if (dto.RoleId == Convert.ToInt32(RoleEnums.Employee))
                role = RoleStrings.Employee;
            else if (dto.RoleId == Convert.ToInt32(RoleEnums.Employee))
                role = RoleStrings.Employee;
            else
                role = string.Empty;

            var claims = new[]
            {
                new Claim(SessionStrings.UserId, Convert.ToString(dto.UserId)),
                new Claim(SessionStrings.RoleId, Convert.ToString(dto.RoleId)),
                new Claim(SessionStrings.Username, dto.Username),
                new Claim(ClaimTypes.Role, role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JWT:SecretKey").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
