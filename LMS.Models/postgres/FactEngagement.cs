using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.postgres
{ 
    public class FactEngagement
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int ContentId { get; set; }
        public int DateId { get; set; }

        public int Views { get; set; }
        public int Clicks { get; set; }
        public int QuizAttempts { get; set; }

        public DimUser User { get; set; }
        public DimCourse Course { get; set; }
    }
}
