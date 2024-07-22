using Microsoft.EntityFrameworkCore;
using WebDataBridge.Domain.Entities;

namespace WebDataBridge.Infrastructure
{
    public class ApplicationDbContext : DbContext //dbcontext is a bridge netween the app and the db
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<Student> students { get; set; } 
        //property for each table in the db used to query, update...
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("students");

                entity.Property(e => e.Id)
                      .HasColumnName("id");

                entity.Property(e => e.Name)
                      .HasColumnName("name");

                entity.Property(e => e.Address)
                      .HasColumnName("address");
                entity.Property(e => e.Age)
                      .HasColumnName("age");
            });
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");
                entity.Property(e => e.CourseID).HasColumnName("course_id");
                entity.Property(e => e.CourseName).HasColumnName("course_name");
                entity.Property(e => e.CourseCode).HasColumnName("course_code");
                entity.Property(e => e.Department).HasColumnName("department");
                entity.Property(e => e.Faculty).HasColumnName("faculty");
                entity.Property(e => e.Credits).HasColumnName("credits");
            });
            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.ToTable("enrollment");

                entity.HasKey(e => new { e.StudentId, e.CourseId });
                entity.Property(e => e.StudentId).HasColumnName("student_id");
                entity.Property(e => e.CourseId).HasColumnName("course_id");
                entity.Property(e => e.EnrollmentDate).HasColumnName("enrollment_date");

                entity.HasOne(e => e.Student)
                      .WithMany(s => s.Enrollments)
                      .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                      .WithMany(c => c.Enrollments)
                      .HasForeignKey(e => e.CourseId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
