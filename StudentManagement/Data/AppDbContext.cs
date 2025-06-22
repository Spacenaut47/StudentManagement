using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Data;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=students.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed courses
        modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, Name = "Math" },
            new Course { Id = 2, Name = "Science" },
            new Course { Id = 3, Name = "History" }
        );
    }
}
