using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;

namespace SchoolApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly SchoolApiContext _context;

        public CourseController(SchoolApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Course.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            var course = await _context.Course
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (course == null)
                return NotFound();

            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(Course course)
        {
            // On peut avant de faire une modification, valider les données reçues
            _context.Course.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Course.FindAsync(id);
            if (course == null)
                return NotFound();

            _context.Course.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

