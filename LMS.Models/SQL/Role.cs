using System.Collections.Generic;

namespace LMS.Models.SQL
{
    public class Role
    {
        public int Id { get; set; } // PK
        public string RoleName { get; set; }
        public string Description { get; set; }

        // Navigation Properties
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
