using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDataBridge.Application.DTOs;
using WebDataBridge.Domain.Entities;

namespace WebDataBridge.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public CourseService(IMapper mapper, ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<List<CourseDto>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return _mapper.Map<List<CourseDto>>(courses);
        }

        public async Task<CourseDto> GetCourseByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            return _mapper.Map<CourseDto>(course);
        }

        public async Task AddCourseAsync(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            await _courseRepository.AddAsync(course);
        }

        public async Task UpdateCourseAsync(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            await _courseRepository.UpdateAsync(course);
        }

        public async Task DeleteCourseAsync(int id)
        {
            await _courseRepository.DeleteByIdAsync(id);
        }
        public async Task<List<CourseDto>> GetCoursesWithStudentsOlderThanAsync(int age)
        {
            var courses = await _courseRepository.GetCoursesWithStudentsOlderThanAsync(age);
            var courseDtos = courses.Select(c => new CourseDto
            {
                CourseId = c.CourseID,
                CourseName = c.CourseName,
                CourseCode = c.CourseCode,
                Department = c.Department,
                Faculty = c.Faculty,
                Credits = c.Credits,
                Students = c.Enrollments.Where(e => e.Student.Age > age)
                                        .Select(e => new StudentDto
                                        {
                                            id = e.Student.Id,
                                            name = e.Student.Name,
                                            age = e.Student.Age,
                                            address = e.Student.Address
                                        }).ToList()
            }).ToList();

            return courseDtos;
        }
        public async Task AssignStudentToCourseAsync(int courseId, int studentId)
        {
            await _courseRepository.AssignStudentToCourseAsync(courseId, studentId);
        }
        public async Task RemoveStudentFromCourseAsync(int courseId, int studentId)
        {
            await _courseRepository.RemoveStudentFromCourseAsync(courseId, studentId);
        }
    }

}


