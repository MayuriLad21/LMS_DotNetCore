using System.Collections.Generic;

namespace LMS.Core.DTOs
{
    public class CourseDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public decimal Fees { get; set; }
        public InstructorDto Instructor { get; set; }
        public List<EnrolledStudentDto> EnrolledStudents { get; set; } = new();
    }

    public class InstructorDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class EnrolledStudentDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompletionStatus { get; set; }
        public string Grade { get; set; }
    }
}
