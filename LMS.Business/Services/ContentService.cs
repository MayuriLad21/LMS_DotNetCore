using LMS.Core.Interfaces;
using LMS.Models.Mongo;
namespace LMS.Business.Services
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _contentRepository;

        public ContentService(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task<ContentModel> CreateContentAsync(ContentModel content)
        {
            // Business logic (e.g. validation) can go here
            if (string.IsNullOrWhiteSpace(content.Title))
                throw new ArgumentException("Title is required");

            return await _contentRepository.CreateAsync(content);
        }

        public async Task<IEnumerable<ContentModel>> GetAllContentsAsync()
        {
            return await _contentRepository.GetAllAsync();
        }
          public Task<ContentModel> GetContentByIdAsync(string id) =>
            _contentRepository.GetByIdAsync(id);

        public Task<bool> UpdateContentAsync(string id, ContentModel content) =>
            _contentRepository.UpdateAsync(id, content);

        public Task<bool> DeleteContentAsync(string id) =>
            _contentRepository.DeleteAsync(id);
    }
}
