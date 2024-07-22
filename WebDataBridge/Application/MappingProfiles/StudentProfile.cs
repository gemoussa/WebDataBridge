using AutoMapper;
using WebDataBridge.Application.DTOs;
using WebDataBridge.Domain.Entities;

namespace WebDataBridge.Application.MappingProfiles
{
    public class StudentProfile: Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
