using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebDataBridge.Application.DTOs;
using WebDataBridge.Domain.Entities;
using WebDataBridge.Domain.Interfaces;
using WebDataBridge.Infrastructure;

namespace WebDataBridge.Application.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentRepository _studentRepository;
        //private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StudentsService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public List<StudentDto> GetAllStudents()
        {
            var students = _studentRepository.GetAll();
            return _mapper.Map<List<StudentDto>>(students);
        }

        public StudentDto GetStudentByID(int id)
        {
            var student = _studentRepository.GetById(id);
            return _mapper.Map<StudentDto>(student);
        }

        public void AddStudent(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
           _studentRepository.Add(student);
        }

        public void DeleteStudent(int id)
        {
          _studentRepository.DeleteById(id);
        }

        public void UpdateStudent(StudentDto studentDto)
        {
            var student = _studentRepository.GetById(studentDto.id);
            if (student != null)
            {
                _mapper.Map(studentDto, student);
                _studentRepository.Update(student);
            }
        }
    }
}
