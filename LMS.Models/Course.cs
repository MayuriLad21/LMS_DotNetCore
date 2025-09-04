using System;
using System.Collections.Generic;

namespace LMS.Models
{
    public class Course
    {
        public int Id { get; set; } // PK
        public string Title { get; set; }
        public string Description { get; set; }
        public int InstructorId { get; set; } // FK

        public int Duration { get; set; } // in hours or weeks
        public decimal Fees { get; set; }
        public DateTime CreatedDate { get; set; } 
        public DateTime ModifiedDate { get; set; }

        // Navigation
        public User Instructor { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
