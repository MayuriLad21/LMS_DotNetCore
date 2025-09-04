using LMS.Business;
using LMS.Core.Interfaces;
using LMS.Data;
using LMS.Models;
using LMS.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Business.Services
{
    public class CourseService : ICourseService
    {
        private readonly SqlDbContext _context;

        public CourseService(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            return await _context.Courses
                .Include(c => c.Instructor)
                .Select(c => new CourseDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    InstructorName = c.Instructor.FirstName + " " + c.Instructor.LastName,
                    Fees = c.Fees,
                    Duration = c.Duration
                })
                .ToListAsync();
        }
    }
}
