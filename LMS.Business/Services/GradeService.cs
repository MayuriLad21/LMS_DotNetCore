using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Interfaces;
using LMS.Models.Mongo;

namespace LMS.Business.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task<IEnumerable<GradeModel>> GetAllAsync() =>
            await _gradeRepository.GetAllAsync();

        public async Task<GradeModel> GetByIdAsync(string id) =>
            await _gradeRepository.GetByIdAsync(id);

        public async Task CreateAsync(GradeModel grade) =>
            await _gradeRepository.CreateAsync(grade);

        public async Task UpdateAsync(string id, GradeModel grade) =>
            await _gradeRepository.UpdateAsync(id, grade);

        public async Task DeleteAsync(string id) =>
            await _gradeRepository.DeleteAsync(id);
    }
}
