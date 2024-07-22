using WebDataBridge.Application.DTOs;

namespace WebDataBridge.Application.Interfaces.Services
{
    public interface IEnrollmentService
    {
        void AddEnrollment(EnrollmentDto enrollmentDto);
        void RemoveEnrollment(int studentId, int courseId);
    }
}
