using AutoMapper;
using WebDataBridge.Application.DTOs;
using WebDataBridge.Domain.Entities;

namespace WebDataBridge.Application.MappingProfiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
        }
    }
}
