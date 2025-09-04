using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LMS.Models.Mongo
{
    public class DocumentModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; } // assignment, notes, syllabus
        public List<DocumentVersion> Versions { get; set; }
    }
}
