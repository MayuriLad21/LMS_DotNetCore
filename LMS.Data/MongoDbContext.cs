using MongoDB.Driver;
using LMS.Models.Mongo;
using System.Diagnostics;
using System.Reflection.Metadata;
using Microsoft.Extensions.Options;

namespace LMS.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<ContentModel> Contents => _database.GetCollection<ContentModel>("Contents");
        public IMongoCollection<GradeModel> Grades => _database.GetCollection<GradeModel>("Grades");
        public IMongoCollection<DocumentModel> Documents => _database.GetCollection<DocumentModel>("Documents");
        public IMongoCollection<LogEntryModel> Logs => _database.GetCollection<LogEntryModel>("Logs");
        public IMongoCollection<DiscussionModel> Discussions => _database.GetCollection<DiscussionModel>("Discussions");
        public IMongoCollection<NotificationModel> Notifications => _database.GetCollection<NotificationModel>("Notifications");

        public IMongoCollection<T> GetCollection<T>(string name) => _database.GetCollection<T>(name);
    }
}
