using System.Security.Cryptography;
using System.Text;
using ejemploApiConServicios.Data;
using ejemploApiConServicios.DTOS;
using ejemploApiConServicios.Interface;
using ejemploApiConServicios.Models;
using ejemploApiConServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ejemploApiConServicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        private readonly ITokenService _tokenService;

        public AccountController(ApplicationDbcontext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        // Método de Registro
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(UserDTO registerDto)
        {
            var userExists = await _context.Users.AnyAsync(x => x.Email == registerDto.Email.ToLower());
            if (userExists) return BadRequest("Email already exists.");

            var user = new User
            {
                Fullname = registerDto.Fullname,
                Email = registerDto.Email.ToLower(),
                Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password) // Asegúrate de que esto esté bien
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully." });
        }

        // Método de Login
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLoginDTO loginDto)
        {
            // Convertir el email a minúsculas
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email.ToLower() == loginDto.Email.ToLower());

            if (user == null)
                return Unauthorized("Invalid email");

            // Verificar la contraseña utilizando BCrypt
            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
                return Unauthorized("Invalid password");

            // Generar y devolver el token
            return Ok(new
            {
                token = _tokenService.CreateToken(user)
            });
        }

        // Verifica si el email ya existe
        private async Task<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email.ToLower());
        }
    }
}
