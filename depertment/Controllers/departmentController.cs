using depertment.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace depertment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class departmentController : ControllerBase
    {
        private readonly Angular_Developer_ProgramContext _context;
        public departmentController(Angular_Developer_ProgramContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetDepartments()
        {
            if (_context.DepartmentModels == null)
            {
                return NotFound();
            }
            return await _context.DepartmentModels.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentModel>> GetDepartment(int id)
        {
            if (_context.DepartmentModels == null)
            {
                return NotFound();
            }
            var department = await _context.DepartmentModels.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, DepartmentModel department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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
        private bool DepartmentExists(int id)
        {
            return (_context.DepartmentModels?.Any(e => e.DepartmentId == id)).GetValueOrDefault();
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentModel>> PostDepartment(DepartmentModel department)
        {
            if (_context.DepartmentModels == null)
            {
                return Problem("Entity set 'angularprojectContext.Departments'  is null.");
            }
            _context.DepartmentModels.Add(department);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DepartmentExists(department.DepartmentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDepartment", new { id = department.DepartmentId }, department);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if (_context.DepartmentModels == null)
            {
                return NotFound();
            }
            var department = await _context.DepartmentModels.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.DepartmentModels.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
