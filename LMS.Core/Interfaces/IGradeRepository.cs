using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Models.Mongo;

namespace LMS.Core.Interfaces
{
    public interface IGradeRepository
    {
        Task<IEnumerable<GradeModel>> GetAllAsync();
        Task<GradeModel> GetByIdAsync(string id);
        Task CreateAsync(GradeModel grade);
        Task UpdateAsync(string id, GradeModel grade);
        Task DeleteAsync(string id);
    }
}
