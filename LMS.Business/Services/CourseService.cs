using LMS.Business;
using LMS.Core.DTOs;
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

        public async Task<IEnumerable<StudentCourseDto>> GetAllCoursesAsync()
        {
            return await _context.Courses
                .Include(c => c.Instructor)
                .Select(c => new StudentCourseDto
                {
                    CourseId = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    InstructorName = c.Instructor.FirstName + " " + c.Instructor.LastName,
                    Fees = c.Fees,
                    Duration = c.Duration
                })
                .ToListAsync();
        }

        public async Task<List<StudentCourseDto>> GetStudentEnrolledCoursesAsync(int userId)
        {
            return await _context.Enrollments
                .AsNoTracking()
                .Where(e => e.UserId == userId)
                .Include(e => e.Course)
                .Select(e => new StudentCourseDto
                {
                    CourseId = e.CourseId, 
                    Title = e.Course.Title,
                    Description = e.Course.Description,
                    Duration = e.Course.Duration,
                    Fees = e.Course.Fees,
                    CompletionStatus = e.CompletionStatus,
                    Grade = e.Grade
                })
                .ToListAsync();
        }

        public async Task<CourseDetailDto> GetCourseDetailsAsync(int courseId)
        {
            try
            {
                var couserdetails =  await _context.Courses
               .AsNoTracking()
               .Where(c => c.Id == courseId)
               .Include(c => c.Instructor)
               .Include(c => c.Enrollments)
                   .ThenInclude(e => e.Student)
               .Select(c => new CourseDetailDto
               {
                   Id = c.Id,
                   Title = c.Title,
                   Description = c.Description,
                   Duration = c.Duration,
                   Fees = c.Fees,
                   Instructor = new InstructorDto
                   {
                       Id = c.Instructor.Id,
                       UserName = c.Instructor.UserName,
                       FirstName = c.Instructor.FirstName,
                       LastName = c.Instructor.LastName,
                       Email = c.Instructor.Email
                   },
                   EnrolledStudents = c.Enrollments.Select(e => new EnrolledStudentDto
                   {
                       Id = e.Student.Id,
                       UserName = e.Student.UserName,
                       FirstName = e.Student.FirstName,
                       LastName = e.Student.LastName,
                       CompletionStatus = e.CompletionStatus,
                       Grade = e.Grade
                   }).ToList()
               })
               .FirstOrDefaultAsync();
                return couserdetails;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public async Task<StudentDashboardSummery> GetStudentDashboardSummeryAsync(int userId)
        {
            // Fetch all enrollments for the student
            var enrollments = await _context.Enrollments
                .Where(e => e.UserId == userId)
                .Include(e => e.Course)
                .ToListAsync();

            var enrolled = enrollments.Count;
            var completed = enrollments.Count(e => e.CompletionStatus == "Completed");
            var inProgress = enrollments.Count(e => e.CompletionStatus == "InProgress");

            return new StudentDashboardSummery
            {
                Enrolled= enrolled,
               Completed= completed,
                InProgress= inProgress
            };
        }
    }
}
