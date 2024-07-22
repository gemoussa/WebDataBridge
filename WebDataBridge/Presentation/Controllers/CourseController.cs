using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDataBridge.Application.DTOs;
using WebDataBridge.Application.Interfaces.Services;
using WebDataBridge.Application.Services;

namespace WebDataBridge.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseDto courseDto)
        {
            if (courseDto == null)
            {
                return BadRequest();
            }

            await _courseService.AddCourseAsync(courseDto);
            return CreatedAtAction(nameof(GetById), new { id = courseDto.CourseId }, courseDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CourseDto courseDto)
        {
            if (courseDto == null || courseDto.CourseId != id)
            {
                return BadRequest();
            }

            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            await _courseService.UpdateCourseAsync(courseDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            await _courseService.DeleteCourseAsync(id);
            return NoContent();
        }

        [HttpPost("{courseId}/students/{studentId}")]
        public async Task<IActionResult> AssignStudentToCourse(int courseId, int studentId)
        {
            try
            {
                await _courseService.AssignStudentToCourseAsync(courseId, studentId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("students-older-than/{age}")]
        public async Task<IActionResult> GetCoursesWithStudentsOlderThan(int age)
        {
            var courses = await _courseService.GetCoursesWithStudentsOlderThanAsync(age);
            return Ok(courses);
        }
        [HttpDelete("{courseId}/students/{studentId}")]
        public async Task<IActionResult> RemoveStudentFromCourse(int courseId, int studentId)
        {
            try
            {
                await _courseService.RemoveStudentFromCourseAsync(courseId, studentId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

