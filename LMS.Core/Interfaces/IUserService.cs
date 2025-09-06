using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Models.DTOs;
using LMS.Models.SQL;

namespace LMS.Core.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string email, string password); 
        Task<User> Register(userRegisterRequest newUser);
        List<string> GetUserRoles(int userId);
        Task<User> GetUserByIdAsync(int userId);  
    }
}
