using System;
using System.Collections.Generic;

namespace LMS.Models.SQL
{
    public class User
    {
        public int Id { get; set; }  // PK
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public DateTime CreatedDate { get; set; } 
        public DateTime ModifiedDate { get; set; } 
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Course> CoursesTaught { get; set; }  // if instructor
        public ICollection<Enrollment> Enrollments { get; set; } // if student
        public ICollection<AssessmentSubmission> AssessmentSubmissions { get; set; }
    }
}
