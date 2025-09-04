using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models.Mongo
{
    public class ClientInfo
    {
        public string Ip { get; set; }
        public string Device { get; set; }
        public string Os { get; set; }
    }
}
