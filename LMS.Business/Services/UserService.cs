using LMS.Core.Interfaces;
using LMS.Data;
using LMS.Models;
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

        public User Authenticate(string username, string password)
        {
            // 🔹 Find user in DB (simple comparison – replace with hashed check later)
            var user = _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefault(u => u.UserName == username && u.PasswordHash == password);

            return user; // return null if not found
        }
    }
}
