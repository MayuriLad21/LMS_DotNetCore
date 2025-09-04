using LMS.Business.Services;
using LMS.Core.Interfaces;
using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LMS.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtTokenService _jwtTokenService;

        public AuthController(IUserService userService, JwtTokenService jwtTokenService)
        {
            _userService = userService;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _userService.Authenticate(request.Username, request.Password);

            if (user == null)
                return Unauthorized(new { message = "Invalid username or password" });

            // 🔹 Create claims (add all roles for this user)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email ?? "")
            };

            foreach (var role in user.UserRoles.Select(ur => ur.Role.RoleName))
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = _jwtTokenService.GenerateToken(claims);

            return Ok(new
            {
                token,
                user = new
                {
                    user.Id,
                    user.UserName,
                    Roles = user.UserRoles.Select(ur => ur.Role.RoleName).ToList()
                }
            });
        }
    }
}
