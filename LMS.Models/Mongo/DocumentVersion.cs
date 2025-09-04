using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.Mongo
{
    public class DocumentVersion
    {
        public int Version { get; set; }
        public string FileUrl { get; set; }
        public DateTime UploadedOn { get; set; }
        public int UploadedBy { get; set; }
    }
}
