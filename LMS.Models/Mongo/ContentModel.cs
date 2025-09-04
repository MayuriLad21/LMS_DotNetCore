using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace LMS.Models.Mongo
{
    public class ContentModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }   // lesson, video, quiz, doc
        public string FileUrl { get; set; }
        public int Version { get; set; } = 1;
        public List<string> Tags { get; set; }
        public string Status { get; set; } // draft, published, archived
        public int UploadedBy { get; set; }
        public DateTime UploadedOn { get; set; } = DateTime.UtcNow;
        public MetadataModel Metadata { get; set; }
    }
}
