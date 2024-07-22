using WebDataBridge.Domain.Entities;

namespace WebDataBridge.Domain.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void DeleteById(int id);
        List<Student> GetStudentsByAge(int age);
    }   
}
