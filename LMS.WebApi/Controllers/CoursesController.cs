using LMS.Business;
using LMS.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Instructor,Student")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("AllCourses")]
        public async Task<IActionResult> Get()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }
        [HttpGet("GetStudentEnrolledCourses")]
        public async Task<IActionResult> GetStudentEnrolledCourses() 
        {
            var userIdClaim = User.FindFirstValue("UserId");
            if (string.IsNullOrWhiteSpace(userIdClaim))
                return Unauthorized("Missing UserId claim in token.");

            if (!int.TryParse(userIdClaim, out var userId))
                return Unauthorized("Invalid UserId claim.");

            var courses = await _courseService.GetStudentEnrolledCoursesAsync(userId);
            return Ok(courses);
        }

        // API6: GET /api/courses/{courseId}
        [HttpGet("GetCourseDetails/{courseId:int}")]
        public async Task<IActionResult> GetCourseDetails(int courseId)
        {
            var course = await _courseService.GetCourseDetailsAsync(courseId);
            if (course == null) return NotFound("Course not found");
            return Ok(course);
        }
    }
}
