using ejemploApiConServicios.Models;
using ejemploApiConServicios.config;
using Microsoft.AspNetCore.Mvc;

namespace ejemploApiConServicios.Controllers.V1.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // Método que genera un JWT
        [HttpPost("generate-token")]
        public async Task<IActionResult> GenerateToken(User user)
        {
            
            var token = JwtTokenGenerator.GenerateJwtToken(user); 
            return Ok($"Acá se te pasa un token: {token}");
        }
    }
}
//esto no sirve... toca hacer login