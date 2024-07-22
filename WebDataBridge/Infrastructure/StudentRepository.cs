using WebDataBridge.Domain.Entities;
using WebDataBridge.Domain.Interfaces;

namespace WebDataBridge.Infrastructure
{
    public class StudentRepository:IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Student> GetAll()
        {
            return _context.students.ToList();
        }
        public Student GetById(int id)
        {
            return _context.students.SingleOrDefault(s => s.Id == id);
        }
        public void Add(Student student)
        {
            _context.students.Add(student);
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.students.Update(student);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var student = _context.students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _context.students.Remove(student);
                _context.SaveChanges();
            }
        }

        public List<Student> GetStudentsByAge(int age)
        {
            return _context.students.Where(s => s.Age > age).ToList();
        }
    }
}
