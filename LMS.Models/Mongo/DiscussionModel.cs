using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Xml.Linq;

namespace LMS.Models.Mongo
{
    public class DiscussionModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int CourseId { get; set; }
        public string ContentId { get; set; } // optional reference
        public int CreatedBy { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public List<CommentModel> Comments { get; set; }
    }
}
