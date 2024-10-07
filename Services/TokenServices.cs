using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ejemploApiConServicios.Interface;
using ejemploApiConServicios.Models;
using Microsoft.IdentityModel.Tokens;

namespace ejemploApiConServicios.Services
{
    public class TokenServices : ITokenService
    {
        private readonly IConfiguration _config;

        public TokenServices(IConfiguration config)
        {
            _config = config;
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Fullname) // Incluye el nombre
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT_SECRET_KEY"])); // Asegúrate de usar la clave correcta
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // Usa HmacSha256 o HmacSha512 con una clave más larga

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
