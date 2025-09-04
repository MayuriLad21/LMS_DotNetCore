using System;

namespace LMS.Models
{
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime AssignedDate { get; set; }

        // Navigation
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
