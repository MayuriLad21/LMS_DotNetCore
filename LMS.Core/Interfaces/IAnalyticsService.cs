using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Interfaces
{
    public interface IAnalyticsService
    {
        Task<object> GetCourseCompletionAsync();
        Task<object> GetEngagementStatsAsync();
        Task<object> GetUserProgressAsync(int userId);
        Task<object> GetTopCoursesAsync(int top = 5);
    }
}

