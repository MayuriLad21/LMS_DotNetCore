using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using LMS.Models.Mongo;

namespace LMS.Core.Interfaces
{
    public interface IContentRepository
    {
        Task<ContentModel> CreateAsync(ContentModel content);
        Task<IEnumerable<ContentModel>> GetAllAsync();
        Task<ContentModel> GetByIdAsync(string id);
        Task<bool> UpdateAsync(string id, ContentModel content);
        Task<bool> DeleteAsync(string id);
    }
}
