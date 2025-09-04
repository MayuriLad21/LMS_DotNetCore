using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Interfaces;
using LMS.Data;
using LMS.Models.Mongo;
using MongoDB.Driver;

namespace LMS.Business.Repository
{
    public class GradeRepository : IGradeRepository
    {
        private readonly IMongoCollection<GradeModel> _grades;

        public GradeRepository(MongoDbContext context)
        {
            _grades = context.GetCollection<GradeModel>("Grades");
        }

        public async Task<IEnumerable<GradeModel>> GetAllAsync() =>
            await _grades.Find(_ => true).ToListAsync();

        public async Task<GradeModel> GetByIdAsync(string id) =>
            await _grades.Find(g => g.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(GradeModel grade) =>
            await _grades.InsertOneAsync(grade);

        public async Task UpdateAsync(string id, GradeModel grade) =>
            await _grades.ReplaceOneAsync(g => g.Id == id, grade);

        public async Task DeleteAsync(string id) =>
            await _grades.DeleteOneAsync(g => g.Id == id);
    }
}
