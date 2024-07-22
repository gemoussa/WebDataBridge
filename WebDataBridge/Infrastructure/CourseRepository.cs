using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDataBridge.Domain.Entities;

using WebDataBridge.Application.Services;

namespace WebDataBridge.Infrastructure
{
    public class CourseRepository(ApplicationDbContext context) : ICourseRepository
    {
        private readonly ApplicationDbContext _context = context;



        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == id);
        }

        public async Task AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Course>> GetCoursesWithStudentsOlderThanAsync(int age)
        {
            return await _context.Courses
                .Include(c => c.Enrollments)
                .ThenInclude(e => e.Student)
                .Where(c => c.Enrollments.Any(e => e.Student.Age > age))
                .ToListAsync();
        }
        public async Task AssignStudentToCourseAsync(int courseId, int studentId)
        {
            var course = await _context.Courses.Include(c => c.Enrollments).FirstOrDefaultAsync(c => c.CourseID == courseId);
            var student = await _context.students.FindAsync(studentId);
            if (course != null && student != null)
            {
                course.Enrollments.Add(new Enrollment { CourseId = courseId, StudentId = studentId });
                await _context.SaveChangesAsync();
            }
        }
        public async Task RemoveStudentFromCourseAsync(int courseId, int studentId)
        {
            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(e => e.CourseId == courseId && e.StudentId == studentId);

            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
