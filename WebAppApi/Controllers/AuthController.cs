using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAppApi.Models;
using WebAppApi.Services.Users;

namespace WebAppApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUsersService _usersService;

        public AuthController(IConfiguration config, IUsersService usersService)
        {
            _config = config;
            _usersService = usersService;
        }

        private string GenerateToken(UserRegister userRegister)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userRegister.Username),
                new Claim(ClaimTypes.Role, userRegister.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public IActionResult Register(UserRegister userRegister)
        {
            _usersService.AddUser(userRegister);

            return Created(
                HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path,
                userRegister
            );
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login(UserLogin userLogin)
        {
            UserRegister? userRegister = _usersService.GetUser(userLogin.Username);
            if (userRegister == null)
            {
                return NotFound($"User {userLogin.Username} not found.");
            }

            if (userRegister.Password != userLogin.Password)
            {
                return Forbid("Invalid password.");
            }

            return Ok(GenerateToken(userRegister));
        }
    }
}