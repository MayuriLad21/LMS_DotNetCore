using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.DTOs
{
    public class UserLoginRequest 
    {
        /// <summary>
        /// 
        /// </summary>
        public required string email { get; set; } 
        /// <summary>
        /// 
        /// </summary>
        public required string Password { get; set; }
    }
}
