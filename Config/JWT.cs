// using Microsoft.AspNetCore.Identity;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.IdentityModel.Tokens;
// using Microsoft.AspNetCore.Mvc;
// using ejemploApiConServicios.DTOS;
// using ejemploApiConServicios.Models;
// using ejemploApiConServicios.Data;

// namespace ejemploApiConServicios.Config;

// [ApiController]
// [Route("api/v1/users")]
// public class JWT : ControllerBase
// {
//     // Property to access the database context.
//     private readonly ApplicationDbcontext Context;

//     // Property to access the application configuration.
//     private readonly IConfiguration _configuration;

//     // Property to handle password hashing.
//     private readonly PasswordHasher<User> _passwordHasher;

//     // Constructor of the controller.
//     // Initializes the database context, configuration, and passwordHasher.
//     public JWT(ApplicationDbcontext context, IConfiguration configuration)
//     {
//         Context = context;
//         _configuration = configuration;
//         _passwordHasher = new PasswordHasher<User>();
//     }

//     // Method to log in a user.
//     // Uses the [HttpPost("Login")] attribute to define the endpoint route.
//     [HttpPost("Login")]
//     public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
//     {
//         // Check if the DTO model is valid.
//         if (!ModelState.IsValid)
//         {
//             return BadRequest(ModelState);
//         }

//         // Find the user in the database by their NickName.
//         var user = await Context.Users.FirstOrDefaultAsync(item => item.Fullname == userDTO.Fullname);
//         if (user == null)
//         {
//             return Unauthorized("Invalid credentials.");
//         }

//         // Verify if the provided password matches the hashed password stored in the database.
//         var passwordResult = _passwordHasher.VerifyHashedPassword(user, user.Password, userDTO.Password);
//         if (passwordResult == PasswordVerificationResult.Failed)
//         {
//             return Unauthorized("Invalid credentials.");
//         }

//         // If authentication is successful, generate a JWT token for the user.
//         var token = GenerateJwtToken(user);

//         // Return an OK response with the user data and JWT token.
//         return Ok(new
//         {
//             message = "Success",
//             data = new
//             {
//                 id = user.Id,
//                 name = user.Fullname,
//                 email = user.Email,
//                 token = token
//             }
//         });
//     }

//     // Private method to generate the JWT.
//     private string GenerateJwtToken(User user)
//     {
//         // Create a security key using the secret key from the configuration.
//         var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT_KEY"]));

//         // Create signing credentials using the security key and HMAC-SHA256 algorithm.
//         var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//         // Define the claims that will be included in the JWT.
//         var claims = new[]
//         {
//             new Claim("Id", user.Id.ToString()), // User Id.
//             new Claim("Name", user.Fullname), // User name.
//             new Claim("Email", user.Email) // User email.
//         };

//         // Create the JWT with the configured parameters.
//         var token = new JwtSecurityToken(
//             issuer: _configuration["JWT_ISSUER"], // Token issuer.
//             audience: _configuration["JWT_AUDIENCE"], // Token audience.
//             claims: claims, // Claims to be included in the token.
//             expires: DateTime.Now.AddMinutes(double.Parse(_configuration["JWT_EXPIRES_IN"])), // Token expiration time.
//             signingCredentials: credentials // Credentials for signing the token.
//         );

//         // Return the JWT as a string.
//         return new JwtSecurityTokenHandler().WriteToken(token);
//     }
// }



