﻿namespace WebDataBridge.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
