using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeForRestApi.Models;
using PracticeProject.Data;

namespace PracticeForRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticeAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public PracticeAPIController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/PracticeAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Practice>>> GetPractices()
        {
            return Ok(await _db.Practices.ToListAsync());
        }

        // GET: api/PracticeAPI/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Practice>> GetPractice(int id)
        {
            var practice = await _db.Practices.FindAsync(id);
            if (practice == null) return NotFound();
            return Ok(practice);
        }

        // POST: api/PracticeAPI
        [HttpPost]
        public async Task<ActionResult<Practice>> CreatePractice([FromBody] Practice practice)
        {
            _db.Practices.Add(practice);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPractice), new { id = practice.Id }, practice);
        }

        // PUT: api/PracticeAPI/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePractice(int id, [FromBody] Practice practice)
        {
            if (id != practice.Id) return BadRequest();

            _db.Entry(practice).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/PracticeAPI/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePractice(int id)
        {
            var practice = await _db.Practices.FindAsync(id);
            if (practice == null) return NotFound();

            _db.Practices.Remove(practice);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
