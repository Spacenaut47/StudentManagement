namespace StudentManagement.Models;

public class Course
{
    public int Id { get; set; }
    public string? Name { get; set; }

    // Navigation property
    public List<Student>? Students { get; set; }
}
