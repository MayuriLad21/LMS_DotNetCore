using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.postgres 
{
    public class DimDate
    {
        public int DateId { get; set; } // surrogate key
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }

        public ICollection<FactCourseProgress> CourseProgressRecords { get; set; }
        public ICollection<FactEngagement> EngagementRecords { get; set; }
    }
}
