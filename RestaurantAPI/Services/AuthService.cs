using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestaurantAPI.Models.Configuration;
using RestaurantAPI.Models.SQLData;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantAPI.Services
{
    public class AuthService(IOptions<JwtConfig> config)
    {
        public string GenerateToken(StaffDATA staff, string username)
        {
            var jwt = config.Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, staff.MaNV),
                new Claim(ClaimTypes.Name, username),
                new Claim("FullName", staff.HoTen),
                new Claim(ClaimTypes.Role, staff.VaiTro)
            };
            var token = new JwtSecurityToken(
                issuer: jwt.Issuer,
                audience: jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(jwt.ExpiryHours),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
