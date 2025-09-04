using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.Mongo
{
    public class CommentModel
    {
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
