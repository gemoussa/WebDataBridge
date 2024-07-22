namespace WebDataBridge.Domain.Entities
{
    public class Course
    {
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public string? CourseCode { get; set; }
        public string? Department { get; set; }
        public string? Faculty { get; set; }
        public byte Credits { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
