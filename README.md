# Todo List API

## Description
This Todo List API is a simple RESTful web service built with ASP.NET Core, Entity Framework Core, and SQL Server. It allows users to manage their todo items, including creating, reading, updating, and deleting tasks.

## Prerequisites
Before you begin, ensure you have met the following requirements:
- [.NET SDK 5.0](https://dotnet.microsoft.com/download/dotnet/5.0) or later
- [Visual Studio](https://visualstudio.microsoft.com/) with ASP.NET and web development workload or [Visual Studio Code](https://code.visualstudio.com/)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB or Express)

## Setup
To set up the Todo List API, follow these steps:
1. Clone the repository:
git clone https://github.com/your-username/todo-list-api.git

2. Open the solution in Visual Studio or the folder in Visual Studio Code.

3. Update the connection string in `appsettings.json` to match your SQL Server instance:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=TodoListDb;Trusted_Connection=True;"
}
```

4. Open the Package Manager Console and run the following command to update the database:
```
Update-Database
```

## Running the Application
To run the Todo List API, follow these steps:

1. In Visual Studio, press Ctrl + F5 to run the application without debugging. In Visual Studio Code, use the terminal to run:

```
dotnet run
```

2. Navigate to https://localhost:5001/swagger in your web browser to view and interact with the Swagger UI, which provides a visual interface for testing the API endpoints.


## API Endpoints
The API includes the following endpoints:

- GET /api/todo: Retrieves all todo items.
- GET /api/todo/{id}: Retrieves a todo item by ID.
- POST /api/todo: Creates a new todo item.
- PUT /api/todo/{id}: Updates an existing todo item.
- DELETE /api/todo/{id}: Deletes a todo item.

## Feedback

- It was easy to complete the task using AI
- It took 2 hours with all documentation
- The code needed to be changed a little in most cases, but after a few requests for correction it can be used
- I used prompts with detail context and prompts that was needed to correct code that was written by AI