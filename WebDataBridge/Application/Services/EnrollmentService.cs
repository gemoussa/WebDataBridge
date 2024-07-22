using AutoMapper;
using WebDataBridge.Application.DTOs;
using WebDataBridge.Application.Interfaces.Services;
using WebDataBridge.Domain.Entities;
using WebDataBridge.Domain.Interfaces;

namespace WebDataBridge.Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IMapper _mapper;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IMapper mapper, IEnrollmentRepository enrollmentRepository)
        {
            _mapper = mapper;
            _enrollmentRepository = enrollmentRepository;
        }

        public void AddEnrollment(EnrollmentDto enrollmentDto)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            _enrollmentRepository.Add(enrollment);
        }

        public void RemoveEnrollment(int studentId, int courseId)
        {
            _enrollmentRepository.Delete(studentId, courseId);
        }
    }
}
