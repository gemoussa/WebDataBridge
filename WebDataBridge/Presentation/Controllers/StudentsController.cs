using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebDataBridge.Application.DTOs;
using WebDataBridge.Application.Services;
using WebDataBridge.Domain.Entities;

namespace WebDataBridge.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentService;
        private readonly IMapper _mapper;

        public StudentsController(IStudentsService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        //get api
        [HttpGet]
        public ActionResult<List<StudentDto>> GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }
        //getbyid api
        [HttpGet("{id}")]
        public ActionResult<StudentDto> GetStudent(int id)
        {
            var student = _studentService.GetStudentByID(id);

            if (student == null)
            {
                return NotFound();
            }

            var studentDto = _mapper.Map<StudentDto>(student);
            return Ok(studentDto);
        }

        [HttpPost]
        public ActionResult AddStudent(StudentDto studentDto)
        {
            _studentService.AddStudent(studentDto);
            return CreatedAtAction(nameof(GetStudent), new { id = studentDto.id }, studentDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = _studentService.GetStudentByID(id);

            if (student == null)
            {
                return NotFound();
            }

            _studentService.DeleteStudent(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentDto studentDto)
        {
            if (id != studentDto.id)
            {
                return BadRequest("Student ID mismatch");
            }

            var existingStudent = _studentService.GetStudentByID(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            _studentService.UpdateStudent(studentDto);
            return NoContent();
        }
      
       

    }

}
