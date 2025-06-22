📘 Student Management Console App
A simple .NET 8 Console application that allows you to manage student records using Entity Framework Core and SQLite. It supports basic CRUD operations and a search feature — all via a console-based menu.

✅ Features
1.Add new students
2.View all student records
3.Update existing student details
4.Delete students by ID
5.Search students by name (case-insensitive)
6.SQLite database integration via EF Core (code-first)

🛠️ Tech Stack
1..NET 8
2.Entity Framework Core
3.SQLite
4.C# (Console App)

🚀 How to Run
1. Clone the repository
   git clone https://github.com/your-username/StudentManagement.git
   cd StudentManagement
   
3. Open the solution in Visual Studio
(Double-click .sln file or open the folder if you're using VS Code)

4. Restore NuGet Packages
  dotnet restore

5. Build the project
   dotnet build
   
7. Run the application
   dotnet run

8.Database Setup
  The SQLite database (students.db) will be auto-created on first run using EnsureCreated().

📦 Dependencies
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Sqlite
Microsoft.EntityFrameworkCore.Tools
(These are installed via NuGet)

📌 Notes
Data is stored in a local file students.db (SQLite format)
No external database setup is required
You can inspect the database using DB Browser for SQLite
