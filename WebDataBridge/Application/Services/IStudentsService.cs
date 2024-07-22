using WebDataBridge.Application.DTOs;
using WebDataBridge.Domain.Entities;

namespace WebDataBridge.Application.Services
{
    public interface IStudentsService
    {
        public List<StudentDto> GetAllStudents();
        public StudentDto GetStudentByID(int id);
        public void AddStudent(StudentDto studentDto);
        void DeleteStudent(int id);
        void UpdateStudent(StudentDto studentDto);
    }
}
