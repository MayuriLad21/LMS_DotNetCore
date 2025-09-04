using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.postgres
{ 
    public class DimCourse
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Difficulty { get; set; }

        public ICollection<FactCourseProgress> CourseProgressRecords { get; set; }
        public ICollection<FactEngagement> EngagementRecords { get; set; }
    }
}
