using System;

namespace LMS.Models.SQL
{
    public class Enrollment
    {
        public int Id { get; set; } // PK
        public int UserId { get; set; } // Student FK
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; } 
        public string CompletionStatus { get; set; } = "NotStarted"; // NotStarted, InProgress, Completed
        public string Grade { get; set; } // optional

        // Navigation
        public User Student { get; set; }
        public Course Course { get; set; }
    }
}
