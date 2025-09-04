using LMS.Core.Interfaces;
using LMS.Data;
using LMS.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using LMS.Models.Mongo;
namespace LMS.Business.Repository
{
    public class ContentRepository : IContentRepository
    {
        private readonly IMongoCollection<ContentModel> _contentCollection;

        public ContentRepository(MongoDbContext context)
        {
            _contentCollection = context.GetCollection<ContentModel>("Contents");
        }

        public async Task<ContentModel> CreateAsync(ContentModel content)
        {
            await _contentCollection.InsertOneAsync(content);
            return content;
        }

        public async Task<IEnumerable<ContentModel>> GetAllAsync()
        {
            return await _contentCollection.Find(_ => true).ToListAsync();
        }


        public async Task<ContentModel> GetByIdAsync(string id) =>
            await _contentCollection.Find(c => c.Id == id).FirstOrDefaultAsync();

        public async Task<bool> UpdateAsync(string id, ContentModel content)
        {
            var result = await _contentCollection.ReplaceOneAsync(c => c.Id == id, content);
            return result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _contentCollection.DeleteOneAsync(c => c.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
