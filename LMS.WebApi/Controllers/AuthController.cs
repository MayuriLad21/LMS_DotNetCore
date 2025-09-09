using LMS.Business.Services;
using LMS.Core.Interfaces;
using LMS.Models.DTOs;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LMS.Models.Enums;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Login([FromBody] UserLoginRequest request)
        {

            try
            {
                var user = _userService.Authenticate(request.email, request.Password);

                if (user == null)
                    return Unauthorized(new { message = "Invalid username or password" });

                // 🔹 Create claims (add all roles for this user)
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
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
                        user.Email,
                        Roles = user.UserRoles.Select(ur => ur.Role.RoleName).ToList()
                    }
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] userRegisterRequest request)
        {
            try
            {
                request.RoleId = (int)RoleEnums.student;
              
                var user = await _userService.Register(request);
                var roles = _userService.GetUserRoles(user.Id);

                // 🔹 Create claims (add all roles for this user)
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
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
                    user.Id,
                    user.UserName,
                    user.Email,
                    Roles = roles,
                    Token = token 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet("GetStudentProfile")]
        [Authorize]
        public async Task<IActionResult> GetStudentUserProfile()
        {
            try
            {
                //var email = User.Identity?.Name;
               // var userId1 = int.Parse(User.FindFirst("UserId").Value);
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim == null)
                    return Unauthorized();
                if (!int.TryParse(userIdClaim.Value, out int userId))
                    return Unauthorized();
                var user = await _userService.GetUserByIdAsync(userId);
                if (user == null)
                    return NotFound("User not found");

                return Ok(new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    user.FirstName,
                    user.LastName,
                    user.Age,
                    user.Gender,
                    user.ContactNumber, 
                    user.CreatedDate,
                    Roles = user.UserRoles.Select(ur => ur.Role.RoleName).ToList()
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        [HttpGet("GetUserProfile/{userID}")]
        [Authorize]
        public async Task<IActionResult> GetUserProfileById(int userID) 
        {
            var user = await _userService.GetUserByIdAsync(userID);

            if (user == null) return NotFound("User not found");

            return Ok(new
            {
                user.Id,
                user.UserName,
                user.Email,
                Roles = user.UserRoles.Select(r => r.Role.RoleName),
                Enrollments = user.Enrollments.Select(e => new {
                    e.CourseId,
                    e.Course.Title,
                    e.CompletionStatus,
                    e.Grade
                })
            });
        }

    }
}
