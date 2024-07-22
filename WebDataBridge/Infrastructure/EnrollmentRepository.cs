using WebDataBridge.Domain.Entities;
using WebDataBridge.Domain.Interfaces;
using System.Linq;

namespace WebDataBridge.Infrastructure.Data.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges(); 
        }

        public void Delete(int studentId, int courseId)
        {
            var enrollment = _context.Enrollments
                .FirstOrDefault(e => e.StudentId == studentId && e.CourseId == courseId);

            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                _context.SaveChanges(); 
            }
        }
    }
}
