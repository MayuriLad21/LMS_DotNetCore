using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.postgres 
{
    public class DimUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }

        public ICollection<FactCourseProgress> CourseProgressRecords { get; set; }
        public ICollection<FactEngagement> EngagementRecords { get; set; }
    }
}
