using StudentManagement.Services;

var service = new StudentService();

while (true)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\n--- Student Management Menu ---");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. View All Students");
    Console.WriteLine("3. Delete Student");
    Console.WriteLine("4. Update Student");
    Console.WriteLine("5. Search Student by Name");
    Console.WriteLine("6. Manage Courses");
    Console.WriteLine("7. Exit");
    Console.Write("Choose an option: ");

    Console.ResetColor();

    var input = Console.ReadLine();
    
    Console.ForegroundColor = ConsoleColor.Yellow;

    switch (input)
    {
        case "1":
            Console.Write("Enter Name: ");
            string? nameInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nameInput))
            {
                Console.WriteLine("Invalid name.");
                break;
            }

            Console.WriteLine("Available Courses:");
            var courses = service.GetAllCourses();
            foreach (var c in courses)
                Console.WriteLine($"{c.Id} - {c.Name}");

            Console.Write("Enter Course ID: ");
            if (!int.TryParse(Console.ReadLine(), out int courseId))
            {
                Console.WriteLine("Invalid course ID.");
                break;
            }

            Console.Write("Enter Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Invalid age. Try again.");
                break;
            }

            service.AddStudent(nameInput, courseId, age);
            Console.WriteLine("Student added successfully.");
            break;

        case "2":
            var students = service.GetAllStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
            }
            else
            {
                Console.WriteLine("\n--- Student List ---");
                foreach (var s in students)
                {
                    Console.WriteLine($"{s.Id} - {s.Name} ({s.Course?.Name}), Age: {s.Age}");
                }
            }
            break;

        case "3":
            Console.Write("Enter Student ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Try again.");
                break;
            }

            service.DeleteStudent(id);
            Console.WriteLine("Student deleted (if ID existed).");
            break;

        case "4":
            Console.Write("Enter Student ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int updateId))
            {
                Console.WriteLine("Invalid ID. Try again.");
                break;
            }

            Console.Write("Enter New Name: ");
            string? newName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("Invalid name.");
                break;
            }

            Console.WriteLine("Available Courses:");
            var allCourses = service.GetAllCourses();
            foreach (var c in allCourses)
                Console.WriteLine($"{c.Id} - {c.Name}");

            Console.Write("Enter New Course ID: ");
            if (!int.TryParse(Console.ReadLine(), out int newCourseId))
            {
                Console.WriteLine("Invalid course ID.");
                break;
            }

            Console.Write("Enter New Age: ");
            if (!int.TryParse(Console.ReadLine(), out int newAge))
            {
                Console.WriteLine("Invalid age. Try again.");
                break;
            }

            service.UpdateStudent(updateId, newName, newCourseId, newAge);
            Console.WriteLine("Student updated (if ID existed).");
            break;

        case "5":
            Console.Write("Enter name to search: ");
            string? searchNameInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchNameInput))
            {
                Console.WriteLine("Invalid search term.");
                break;
            }

            var results = service.SearchStudentsByName(searchNameInput);
            if (results.Count == 0)
            {
                Console.WriteLine("No students found with that name.");
            }
            else
            {
                Console.WriteLine("\n--- Search Results ---");
                foreach (var student in results)
                {
                    Console.WriteLine($"{student.Id} - {student.Name} ({student.Course?.Name}), Age: {student.Age}");
                }
            }
            break;

        case "6":
            while (true)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n--- Course Management ---");
                Console.WriteLine("1. Add Course");
                Console.WriteLine("2. View All Courses");
                Console.WriteLine("3. Update Course");
                Console.WriteLine("4. Delete Course");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Choose an option: ");
                var courseInput = Console.ReadLine();

                switch (courseInput)
                {
                    case "1":
                        Console.Write("Enter course name: ");
                        string? cname = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(cname)) break;
                        service.AddCourse(cname);
                        Console.WriteLine("Course added.");
                        break;

                    case "2":
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        var courses1 = service.GetAllCourses();
                        Console.WriteLine("\n--- The List of Courses ---\n");
                        foreach (var c in courses1)
                            Console.WriteLine($"{c.Id} - {c.Name}");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;

                    case "3":
                        Console.Write("Enter Course ID to update: ");
                        if (!int.TryParse(Console.ReadLine(), out int cid)) break;
                        Console.Write("Enter new course name: ");
                        string? newCname = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newCname)) break;
                        service.UpdateCourse(cid, newCname);
                        Console.WriteLine("Course updated.");
                        break;

                    case "4":
                        Console.Write("Enter Course ID to delete: ");
                        if (!int.TryParse(Console.ReadLine(), out int delCid)) break;
                        service.DeleteCourse(delCid);
                        Console.WriteLine("Course deleted.");
                        break;

                    case "5":
                        goto EndCourseMenu;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        EndCourseMenu:
            break;


        case "7":
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Exiting...");
            Console.ResetColor();
            return;

        default:
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}
