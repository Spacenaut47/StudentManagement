namespace StudentManagement.Models;

public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }

    public int CourseId { get; set; }         // Foreign key
    public Course? Course { get; set; }       // Navigation property
}
