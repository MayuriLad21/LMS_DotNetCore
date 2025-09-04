using LMS.Core.Interfaces;
using LMS.Models.Mongo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeModel>>> GetAll() =>
            Ok(await _gradeService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<GradeModel>> GetById(string id)
        {
            var grade = await _gradeService.GetByIdAsync(id);
            if (grade == null) return NotFound();
            return Ok(grade);
        }

        [HttpPost]
        public async Task<ActionResult> Create(GradeModel grade)
        {
            await _gradeService.CreateAsync(grade);
            return CreatedAtAction(nameof(GetById), new { id = grade.Id }, grade);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, GradeModel grade)
        {
            var existing = await _gradeService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            grade.Id = id;
            grade.UpdatedOn = System.DateTime.UtcNow;

            await _gradeService.UpdateAsync(id, grade);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var existing = await _gradeService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _gradeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
