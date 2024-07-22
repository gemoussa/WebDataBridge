namespace WebDataBridge.Application.DTOs
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? CourseCode { get; set; }
        public string? Department { get; set; }
        public string? Faculty { get; set; }
        public byte Credits { get; set; }
        public List<StudentDto>? Students { get; set; }

    }
}
