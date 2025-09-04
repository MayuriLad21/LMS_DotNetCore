using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.Mongo
{
    public class GradeHistoryModel
    {
        public int Attempt { get; set; }
        public int Score { get; set; }
        public string GradeValue { get; set; }
        public DateTime GradedOn { get; set; }
    }
}
