using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ejemploApiConServicios.Models;
using Microsoft.IdentityModel.Tokens;


namespace ejemploApiConServicios.config
{
    public partial class JwtTokenGenerator
    {
        public static string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };

            // Obtener variables de entorno
            var jwtKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
            var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
            var jwtExpiresIn = Environment.GetEnvironmentVariable("JWT_EXPIRES_IN");

            // Validar que las variables existen
            if (string.IsNullOrEmpty(jwtKey) || string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience))
            {
                throw new InvalidOperationException("JWT configuration values are missing.");
            }

            // Validar longitud de la clave
            if (jwtKey.Length < 32)
            {
                throw new InvalidOperationException("JWT_KEY must be at least 256 bits long.");
            }

            // Validar y convertir el tiempo de expiración
            if (string.IsNullOrEmpty(jwtExpiresIn) || !double.TryParse(jwtExpiresIn, out double expiresInMinutes))
            {
                throw new InvalidOperationException("JWT_EXPIRES_IN is missing or invalid.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresInMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}



