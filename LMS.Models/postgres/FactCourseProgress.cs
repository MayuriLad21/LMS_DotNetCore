using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.postgres 
{
    public class FactCourseProgress
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int DateId { get; set; }

        public double CompletionPercent { get; set; }
        public int TimeSpentMinutes { get; set; }
        public string ProgressStatus { get; set; }

        public DimUser User { get; set; }
        public DimCourse Course { get; set; }
    }

}
