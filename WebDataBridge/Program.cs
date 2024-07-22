using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebDataBridge.Application.MappingProfiles;
using WebDataBridge.Infrastructure;
using AutoMapper;
using WebDataBridge.Application.Services;
using WebDataBridge.Application.Interfaces.Services;
using WebDataBridge.Domain.Interfaces;
using WebDataBridge.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register DbContext with PostgreSQL provider.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register AutoMapper with the assembly containing the profiles.
builder.Services.AddAutoMapper(typeof(StudentProfile).Assembly);
builder.Services.AddAutoMapper(typeof(CourseProfile).Assembly);
builder.Services.AddAutoMapper(typeof(EnrollmentProfile).Assembly);

// Register Service.
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
