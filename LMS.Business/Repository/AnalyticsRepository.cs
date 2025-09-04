using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Interfaces;
using LMS.Data;
using LMS.Models.postgres;
using Microsoft.EntityFrameworkCore;

namespace LMS.Business.Repository
{
    public class AnalyticsRepository : IAnalyticsRepository
    {
        private readonly AnalyticsDbContext _context;
        public AnalyticsRepository(AnalyticsDbContext context) => _context = context;

        public async Task<Dictionary<string, double>> GetAvgCompletionPerCourseAsync()
        {
            return await _context.CourseProgress
                .GroupBy(c => c.Course.Title)
                .Select(g => new { Course = g.Key, AvgCompletion = g.Average(x => x.CompletionPercent) })
                .ToDictionaryAsync(x => x.Course, x => x.AvgCompletion);
        }

        public async Task<Dictionary<string, (int Views, int Clicks, int QuizAttempts)>> GetEngagementStatsAsync()
        {
            return await _context.Engagements
                .GroupBy(e => e.Course.Title)
                .Select(g => new {
                    Course = g.Key,
                    Views = g.Sum(x => x.Views),
                    Clicks = g.Sum(x => x.Clicks),
                    QuizAttempts = g.Sum(x => x.QuizAttempts)
                })
                .ToDictionaryAsync(
                    x => x.Course,
                    x => (x.Views, x.Clicks, x.QuizAttempts)
                );
        }

        public async Task<IEnumerable<FactCourseProgress>> GetUserProgressAsync(int userId)
        {
            return await _context.CourseProgress
                .Include(f => f.Course)
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<TopCourseDto>> GetTopCoursesAsync(int top = 5)
        {
            return await _context.CourseProgress
                .GroupBy(c => c.Course.Title)
                .Select(g => new TopCourseDto
                {
                    Course = g.Key,
                    Completion = g.Average(x => x.CompletionPercent)
                })
                .OrderByDescending(x => x.Completion)
                .Take(top)
                .ToListAsync();
        }
    }
}
