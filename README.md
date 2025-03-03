Employee API - Backend

📌 Overview

This is the backend API for the Employee Management System. It is built using .NET Core, Entity Framework Core (EF Core), and follows the Repository & Service Pattern to ensure clean and maintainable code.

✨ Features

CRUD operations for managing employees.

Uses EF Core Migrations to handle database schema updates.

Implements soft delete for employee records.

Structured with Repository & Service Pattern following SOLID principles.

Logging is implemented for better debugging and error tracking.

Global Exception Handling Middleware to standardize error responses.

🔧 Prerequisites

Ensure you have the following installed:

.NET SDK 7.0+

SQL Server (SSMS) or LocalDB

Postman (Optional for API testing)

🚀 Setup Instructions

1️⃣ Clone the Repository

git clone https://github.com/your-repo/EmployeeAPI.git
cd EmployeeAPI

2️⃣ Configure the Database Connection

Modify the appsettings.json file:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True"
}

3️⃣ Install Dependencies

dotnet restore

4️⃣ Apply Migrations & Update Database

dotnet ef migrations add InitialCreate
dotnet ef database update

5️⃣ Run the API

dotnet run

The API should now be running on http://localhost:5000 or https://localhost:5001.

🌍 API Endpoints

Method

Endpoint

Description

GET

/api/employees/{id}

Get employee by ID

GET

/api/employees

Get all employees

POST

/api/employees

Add a new employee

PUT

/api/employees/{id}

Update employee details

DELETE

/api/employees/{id}

Soft delete an employee

📁 Project Structure

📂 EmployeeAPI/
│── 📂 Controllers/
│   └── 📝 EmployeesController.cs
│── 📂 Services/
│   └── ⚙️ EmployeeService.cs
│── 📂 Repositories/
│   └── 🏛️ EmployeeRepository.cs
│── 📂 Data/
│   └── 🗄️ EmployeeDbContext.cs
│── 📂 Models/
│   └── 📜 Employee.cs
│── 📂 Middleware/
│   └── 🔥 ExceptionHandlingMiddleware.cs
│── 🛠️ appsettings.json
│── 🚀 Program.cs

📝 Logging

Serilog or built-in .NET ILogger is used for logging.

Logs are written to the console and optionally to a file or database.

❗ Exception Handling

A global exception handling middleware is used to catch and format errors properly. This prevents repetitive try-catch blocks in controllers.

🔜 My Next Steps

Is To 

Implement Authentication & Authorization (JWT)

Add Unit Tests

Optimize Database Queries

🤝 Contributing

Fork the repository

Create a new feature branch

Commit and push your changes

Open a pull request
