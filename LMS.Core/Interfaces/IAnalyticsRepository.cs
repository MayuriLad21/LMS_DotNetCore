using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Models.postgres;

namespace LMS.Core.Interfaces
{
    public interface IAnalyticsRepository
    {
        Task<Dictionary<string, double>> GetAvgCompletionPerCourseAsync();
        Task<Dictionary<string, (int Views, int Clicks, int QuizAttempts)>> GetEngagementStatsAsync();
        Task<IEnumerable<FactCourseProgress>> GetUserProgressAsync(int userId);
        Task<IEnumerable<TopCourseDto>> GetTopCoursesAsync(int top = 5);
    }
}
