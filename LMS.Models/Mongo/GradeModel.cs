using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LMS.Models.Mongo
{
    public class GradeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public string ContentId { get; set; } // quiz/assignment reference
        public int Attempt { get; set; }
        public int Score { get; set; }
        public string GradeValue { get; set; }
        public string Feedback { get; set; }
        public DateTime SubmittedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime GradedOn { get; set; } 
        
        public List<GradeHistoryModel> History { get; set; }
    }
}
