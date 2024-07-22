using WebDataBridge.Domain.Entities;
using System.Collections.Generic;
using WebDataBridge.Application.DTOs;

namespace WebDataBridge.Application.Services
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int id);
        Task AddAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteByIdAsync(int id);
       Task<List<Course>> GetCoursesWithStudentsOlderThanAsync(int age);
        Task AssignStudentToCourseAsync(int courseId, int studentId);
        Task RemoveStudentFromCourseAsync(int courseId, int studentId);


    }
}
