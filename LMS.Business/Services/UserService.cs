using Azure.Core;
using LMS.Core.Interfaces;
using LMS.Data;
using LMS.Models;
using LMS.Models.DTOs;
using LMS.Models.SQL;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Business.Services
{
    public class UserService : IUserService
    {
        private readonly SqlDbContext _context;

        public UserService(SqlDbContext context)
        {
            _context = context;
        }

        public User Authenticate(string email, string password)
        {
            // 🔹 Find user in DB (simple comparison – replace with hashed check later)
            var user = _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefault(u => u.Email == email);

            if (user == null)
                throw new Exception("User not found");

            // hash the password entered by user
            var hashedInput = HashPassword(password);

            // compare with stored hash
            if (user.PasswordHash != hashedInput) {

                user.PasswordHash = hashedInput;
                _context.Users.Update(user);
                 _context.SaveChanges();
                throw new Exception("Invalid password");

            }
               

            return user; // return null if not found
        }

        public async Task<User> Register(userRegisterRequest request)
        {
            if (_context.Users.Any(u => u.Email == request.Email || u.UserName == request.UserName))
                throw new Exception("User already exists");

            
            var newUser = new User 
            {
                UserName = request.UserName,
                Email = request.Email,
                PasswordHash = HashPassword(request.PasswordHash),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
                Gender = request.Gender,
                ContactNumber = request.ContactNumber,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };

            _context.Users.Add(newUser);
           await _context.SaveChangesAsync();

            var role = _context.Roles.FirstOrDefault(r => r.Id == request.RoleId);
            if (role == null)
                throw new Exception("Invalid role");

            _context.UserRoles.Add(new UserRole
            {
                UserId = newUser.Id,
                RoleId = role.Id
            });

           await _context.SaveChangesAsync();

            return newUser;
        }

        public List<string> GetUserRoles(int userId)
        {
            return _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.Role.RoleName)
                .ToList();
        }
        private string HashPassword(string password)
        {
            // simple hash for demo; replace with stronger hashing later (e.g. BCrypt)
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            try
            {
                var userdetails = _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .Include(u => u.Enrollments).ThenInclude(h => h.Course)
                .FirstOrDefault(u => u.Id == userId);

                return userdetails;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

    }
}
