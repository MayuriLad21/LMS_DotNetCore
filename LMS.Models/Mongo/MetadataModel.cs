using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.Mongo
{
    public class MetadataModel
    {
        public double SizeMB { get; set; }
        public string MimeType { get; set; }
        public string Language { get; set; }
        public int DurationMin { get; set; } // for videos
    }
}
