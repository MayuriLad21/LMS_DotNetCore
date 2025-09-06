using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.SQL
{
    public class AssessmentSubmission
    {
        public int Id { get; set; }

        public int AssessmentId { get; set; }
        public Assessments Assessment { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime StartedAt { get; set; }
        public DateTime? SubmittedAt { get; set; }

        public double? Score { get; set; }
    }
}
