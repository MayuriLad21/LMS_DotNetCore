using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LMS.Models.Mongo
{
    public class LogEntryModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; } // view, submit, login, logout
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string CourseId { get; set; }
        public string ContentId { get; set; }
        public ClientInfo ClientInfo { get; set; }
    }
}
