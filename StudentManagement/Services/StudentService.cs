using StudentManagement.Data;
using StudentManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Services;

public class StudentService
{
    private readonly AppDbContext _context;

    public StudentService()
    {
        _context = new AppDbContext();
        _context.Database.EnsureCreated();
    }

    public void AddStudent(string name, int courseId, int age)
    {
        if (string.IsNullOrWhiteSpace(name) || age < 1 || age > 120)
        {
            Console.WriteLine("Invalid name or age.");
            return;
        }

        var courseExists = _context.Courses.Any(c => c.Id == courseId);
        if (!courseExists)
        {
            Console.WriteLine("Course ID does not exist.");
            return;
        }

        var student = new Student
        {
            Name = name,
            Age = age,
            CourseId = courseId
        };

        _context.Students.Add(student);
        _context.SaveChanges();
    }


    public List<Student> GetAllStudents()
    {
        return _context.Students.Include(s => s.Course).ToList();
    }

    public List<Course> GetAllCourses()
    {
        return _context.Courses.ToList();
    }

    public void DeleteStudent(int id)
    {
        var student = _context.Students.Find(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }

    public void UpdateStudent(int id, string name, int courseId, int age)
    {
        var student = _context.Students.Find(id);
        if (student != null)
        {
            student.Name = name;
            student.Age = age;
            student.CourseId = courseId;
            _context.SaveChanges();
        }
    }


    public List<Student> SearchStudentsByName(string name)
    {
        return _context.Students
                       .AsEnumerable()
                       .Where(s => !string.IsNullOrEmpty(s.Name) &&
                                   s.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                       .ToList();
    }

    public void AddCourse(string name)
    {
        if (_context.Courses.Any(c => c.Name!.ToLower() == name.ToLower()))
        {
            Console.WriteLine("Course with this name already exists.");
            return;
        }
        var course = new Course { Name = name };
        _context.Courses.Add(course);
        _context.SaveChanges();
    }

    public void UpdateCourse(int id, string newName)
    {
        var course = _context.Courses.Find(id);
        if (course != null)
        {
            course.Name = newName;
            _context.SaveChanges();
        }
    }

    public void DeleteCourse(int id)
    {
        var course = _context.Courses
                            .Include(c => c.Students)
                            .FirstOrDefault(c => c.Id == id);

        if (course == null)
        {
            Console.WriteLine("Course not found.");
            return;
        }

        if (course.Students != null && course.Students.Count > 0)
        {
            Console.WriteLine("Cannot delete: Course has students assigned.");
            return;
        }

        _context.Courses.Remove(course);
        _context.SaveChanges();
    }
}
