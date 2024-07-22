using AutoMapper;
using WebDataBridge.Application.DTOs;
using WebDataBridge.Domain.Entities;

namespace WebDataBridge.Application.MappingProfiles
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
        }
    }
}
