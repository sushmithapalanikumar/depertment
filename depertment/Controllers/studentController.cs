using depertment.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace depertment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentController : ControllerBase
    {
        private readonly Angular_Developer_ProgramContext _context;

        public studentController(Angular_Developer_ProgramContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetStudents()
        {
            if (_context.StudentModels == null)
            {
                return NotFound();
            }
            return await _context.StudentModels.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudent(int id)
        {
            if (_context.StudentModels == null)
            {
                return NotFound();
            }
            var student = await _context.StudentModels.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentModel student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<StudentModel>> PostStudent(StudentModel student)
        {
            if (_context.StudentModels == null)
            {
                return Problem("Entity set 'angularprojectContext.Students'  is null.");
            }
            _context.StudentModels.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (_context.StudentModels == null)
            {
                return NotFound();
            }
            var student = await _context.StudentModels.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.StudentModels.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return (_context.StudentModels?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
