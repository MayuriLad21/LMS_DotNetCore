using LMS.Core.DTOs;
using LMS.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Core.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<StudentCourseDto>> GetAllCoursesAsync();
        Task<List<StudentCourseDto>> GetStudentEnrolledCoursesAsync(int userId); 
        Task<CourseDetailDto> GetCourseDetailsAsync(int courseId);
    }
}
