using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.DTOs
{
    public class StudentDashboardSummery
    {
        public int Enrolled { get; set; }
        public int Completed { get; set; }
        public int InProgress { get; set; }  

    }
}
