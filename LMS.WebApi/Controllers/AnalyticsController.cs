using LMS.Business.Services;
using LMS.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _service;
        public AnalyticsController(IAnalyticsService service) => _service = service;

        [HttpGet("course-completion")]
        public async Task<IActionResult> GetCourseCompletion() =>
            Ok(await _service.GetCourseCompletionAsync());

        [HttpGet("engagement")]
        public async Task<IActionResult> GetEngagement() =>
            Ok(await _service.GetEngagementStatsAsync());

        [HttpGet("user-progress/{userId}")]
        public async Task<IActionResult> GetUserProgress(int userId) =>
            Ok(await _service.GetUserProgressAsync(userId));


        [HttpGet("top-courses")]
        public async Task<IActionResult> GetTopCourses()
        {
            var result = await _service.GetTopCoursesAsync();
            return Ok(result);
        }

    }
}

