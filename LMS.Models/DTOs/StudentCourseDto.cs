using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.DTOs
{
    public class StudentCourseDto
    {
        public int CourseId { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public string InstructorName { get; set; }
        public decimal Fees { get; set; }
        public int Duration { get; set; }
        public string CompletionStatus { get; set; }
        public string Grade { get; set; }
    }
}
