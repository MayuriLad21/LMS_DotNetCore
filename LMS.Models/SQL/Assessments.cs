using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.SQL
{
    public class Assessments
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<AssessmentSubmission> Submissions { get; set; }
    }
}
