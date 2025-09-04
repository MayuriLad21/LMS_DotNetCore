using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class LoginRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public required string Username { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public required string Password { get; set; }
    }
}
