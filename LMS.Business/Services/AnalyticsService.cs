using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Interfaces;

namespace LMS.Business.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly IAnalyticsRepository _repo;
        public AnalyticsService(IAnalyticsRepository repo) => _repo = repo;

        public async Task<object> GetCourseCompletionAsync() =>
            await _repo.GetAvgCompletionPerCourseAsync();

        public async Task<object> GetEngagementStatsAsync() =>
            await _repo.GetEngagementStatsAsync();

        public async Task<object> GetUserProgressAsync(int userId) =>
            await _repo.GetUserProgressAsync(userId);

        public async Task<object> GetTopCoursesAsync(int top = 5) =>
            await _repo.GetTopCoursesAsync(top);
    }
}
