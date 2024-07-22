using WebDataBridge.Application.DTOs;
using System.Collections.Generic;
using WebDataBridge.Domain.Entities;
using WebDataBridge.Infrastructure;

namespace WebDataBridge.Application.Services
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetAllCoursesAsync();
        Task<CourseDto> GetCourseByIdAsync(int id);
        Task AddCourseAsync(CourseDto courseDto);
        Task UpdateCourseAsync(CourseDto courseDto);
        Task DeleteCourseAsync(int id);
        Task<List<CourseDto>> GetCoursesWithStudentsOlderThanAsync(int age);
        Task AssignStudentToCourseAsync(int courseId, int studentId);
        Task RemoveStudentFromCourseAsync(int courseId, int studentId);
    }
}
