using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LMS.Models.Mongo
{
    public class NotificationModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public string Type { get; set; } // info, reminder, deadline, grade
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;
    }
}
