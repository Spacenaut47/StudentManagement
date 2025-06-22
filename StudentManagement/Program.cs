using StudentManagement.Services;

var service = new StudentService();

while (true)
{
    Console.WriteLine("\n--- Student Management Menu ---");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. View All Students");
    Console.WriteLine("3. Delete Student");
    Console.WriteLine("4. Update Student");
    Console.WriteLine("5. Search Student by Name");
    Console.WriteLine("6. Exit");
    Console.Write("Choose an option: ");

    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.Write("Enter Name: ");
            string? name = Console.ReadLine();
            Console.Write("Enter Course: ");
            string? course = Console.ReadLine();
            Console.Write("Enter Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Invalid age.");
                break;
            }
            service.AddStudent(name!, course!, age);
            Console.WriteLine("Student added.");
            break;

        case "2":
            var students = service.GetAllStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
            }
            else
            {
                foreach (var s in students)
                    Console.WriteLine($"{s.Id} - {s.Name} ({s.Course}), Age: {s.Age}");
            }
            break;

        case "3":
            Console.Write("Enter Student ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                service.DeleteStudent(id);
                Console.WriteLine("Deleted (if exists).");
            }
            break;

        case "4":
            Console.Write("Enter Student ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int updateId)) break;

            Console.Write("Enter New Name: ");
            string? newName = Console.ReadLine();

            Console.Write("Enter New Course: ");
            string? newCourse = Console.ReadLine();

            Console.Write("Enter New Age: ");
            if (!int.TryParse(Console.ReadLine(), out int newAge)) break;

            service.UpdateStudent(updateId, newName!, newCourse!, newAge);
            Console.WriteLine("Updated (if exists).");
            break;

        case "5":
            Console.Write("Enter name to search: ");
            string? searchName = Console.ReadLine();
            var results = service.SearchStudentsByName(searchName!);
            foreach (var s in results)
                Console.WriteLine($"{s.Id} - {s.Name} ({s.Course}), Age: {s.Age}");
            break;

        case "6":
            Console.WriteLine("Exiting...");
            return;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}
