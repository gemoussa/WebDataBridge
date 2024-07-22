using WebDataBridge.Domain.Entities;

namespace WebDataBridge.Domain.Interfaces
{
    public interface IEnrollmentRepository
    {
        void Add(Enrollment enrollment);
        void Delete(int studentId, int courseId);
    }
}
