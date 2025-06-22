📘 Student Management Console App
A simple .NET 8 Console application that allows you to manage student records using Entity Framework Core and SQLite. It supports basic CRUD operations and a search feature — all via a console-based menu.

✅ Features
Add new students

View all student records

Update existing student details

Delete students by ID

Search students by name (case-insensitive)

SQLite database integration via EF Core (code-first)

🛠️ Tech Stack
.NET 8

Entity Framework Core

SQLite

C# (Console App)

📂 Folder Structure
lua
Copy
Edit
StudentManagement/
├── Models/
│   └── Student.cs
├── Data/
│   └── AppDbContext.cs
├── Services/
│   └── StudentService.cs
├── Program.cs
└── students.db   <-- created at runtime
🚀 How to Run
Clone the repository

bash
Copy
Edit
git clone https://github.com/your-username/StudentManagement.git
cd StudentManagement
Open the solution in Visual Studio
(Double-click .sln file or open the folder if you're using VS Code)

Restore NuGet Packages

nginx
Copy
Edit
dotnet restore
Build the project

nginx
Copy
Edit
dotnet build
Run the application

arduino
Copy
Edit
dotnet run
Database Setup
The SQLite database (students.db) will be auto-created on first run using EnsureCreated().

🧪 Sample Console Menu
pgsql
Copy
Edit
--- Student Management Menu ---
1. Add Student
2. View All Students
3. Delete Student
4. Update Student
5. Search Student by Name
6. Exit
📦 Dependencies
Microsoft.EntityFrameworkCore

Microsoft.EntityFrameworkCore.Sqlite

Microsoft.EntityFrameworkCore.Tools

(These are installed via NuGet)

📌 Notes
Data is stored in a local file students.db (SQLite format)

No external database setup is required

You can inspect the database using DB Browser for SQLite
