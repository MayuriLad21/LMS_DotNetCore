using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using LMS.Models.Mongo;

namespace LMS.Core.Interfaces
{
    public interface IContentService
    {
        Task<ContentModel> CreateContentAsync(ContentModel content);
        Task<IEnumerable<ContentModel>> GetAllContentsAsync();
        //Task<ContentModel> AddContentAsync(ContentModel content);
        //Task<List<ContentModel>> GetContentsAsync();
        Task<ContentModel> GetContentByIdAsync(string id);
        Task<bool> UpdateContentAsync(string id, ContentModel content);
        Task<bool> DeleteContentAsync(string id);
    }
}
