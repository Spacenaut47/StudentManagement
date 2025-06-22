# 📘 Student Management Console App

A simple .NET 8 Console application that allows you to manage student records using **Entity Framework Core** and **SQLite**. It supports basic **CRUD operations** and a search feature — all via a console-based menu.

---

## ✅ Features

- Add new students  
- View all student records  
- Update existing student details  
- Delete students by ID  
- Search students by name (case-insensitive)  
- SQLite database integration via EF Core (code-first)

---

## 🛠️ Tech Stack

- .NET 8  
- Entity Framework Core  
- SQLite  
- C# (Console App)

---

## 🚀 How to Run

1. **Clone the repository**
   ```bash
   git clone https://github.com/Spacenaut47/StudentManagement.git
   cd StudentManagement
   
**Open the solution in Visual Studio**
(Double-click .sln file or open the folder if using VS Code)

**Restore NuGet Packages**
```bash
   dotnet restore
   dotnet build
   Add-Migration InitialSetup
   Update-Database
   dotnet run

**📦 Dependencies**
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Tools
(Installed via NuGet Package Manager)

