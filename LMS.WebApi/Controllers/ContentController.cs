using LMS.Core.Interfaces;
using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LMS.Models.Mongo;

namespace LMS.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContentModel content)
        {
            var created = await _contentService.CreateContentAsync(content);
            return Ok(created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contents = await _contentService.GetAllContentsAsync();
            return Ok(contents);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var content = await _contentService.GetContentByIdAsync(id);
            if (content == null) return NotFound();
            return Ok(content);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, ContentModel content)
        {
            var updated = await _contentService.UpdateContentAsync(id, content);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _contentService.DeleteContentAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
