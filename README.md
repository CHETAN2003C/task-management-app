# Task Management Application

A modern Blazor Server-based task management web application built with .NET 8, featuring a clean UI and SQLite database.

## Features

- ✅ Create, read, update, and delete tasks
- 📊 Task prioritization (Low, Medium, High)
- 📅 Due date tracking
- ✔️ Mark tasks as complete/incomplete
- 🎨 Modern, responsive UI design
- 📱 Mobile-friendly interface
- 🔍 Filter tasks by status (All, Pending, Completed)
- 💾 SQLite database for data persistence

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A code editor (Visual Studio, VS Code, or Rider)

## Getting Started

### 1. Restore Dependencies

```powershell
dotnet restore
```

### 2. Build the Project

```powershell
dotnet build
```

### 3. Run the Application

```powershell
dotnet run
```

The application will start and be available at:
- HTTPS: `https://localhost:5001`
- HTTP: `http://localhost:5000`

## Project Structure

```
TaskManagementApp/
├── Models/              # Data models
│   └── TaskItem.cs
├── Data/               # Database context
│   └── ApplicationDbContext.cs
├── Services/           # Business logic
│   └── TaskService.cs
├── Pages/              # Blazor pages/components
│   ├── Index.razor
│   ├── TaskList.razor
│   ├── CreateTask.razor
│   ├── EditTask.razor
│   └── _Host.cshtml
├── Shared/             # Shared components
│   ├── MainLayout.razor
│   └── NavMenu.razor
├── wwwroot/            # Static files
│   └── css/
│       └── app.css
├── Program.cs          # Application entry point
├── appsettings.json    # Configuration
└── TaskManagementApp.csproj
```

## Technologies Used

- **ASP.NET Core 8.0** - Web framework
- **Blazor Server** - UI framework
- **Entity Framework Core 8.0** - ORM
- **SQLite** - Database
- **C# 12** - Programming language

## Features Overview

### Home Page
- Dashboard with task statistics
- Quick overview of total, pending, completed, and high-priority tasks
- Feature highlights

### Task List
- View all tasks in a card-based layout
- Filter by status (All/Pending/Completed)
- Quick actions: Edit, Delete, Toggle completion
- Priority badges and due date indicators
- Overdue task highlighting

### Create Task
- Form to add new tasks
- Fields: Title, Description, Due Date, Priority
- Client-side validation
- Responsive design

### Edit Task
- Update existing task details
- Pre-filled form with current values
- Mark task as completed

## Database

The application uses SQLite with the following configuration:
- Database file: `tasks.db` (created automatically)
- Connection string in `appsettings.json`
- Automatic database creation on first run

## Customization

### Change Database
Edit `appsettings.json` to use a different SQLite file or connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=your-database.db"
  }
}
```

### Styling
Modify `wwwroot/css/app.css` to customize the appearance.

## Troubleshooting

### Port Already in Use
If ports 5000/5001 are already in use, you can specify different ports:

```powershell
dotnet run --urls "http://localhost:5002;https://localhost:5003"
```

### Database Issues
Delete the `tasks.db` file to reset the database:

```powershell
Remove-Item tasks.db
```

Then restart the application to create a fresh database.

## License

This project is open source and available for educational purposes.

## Support

For issues or questions, please create an issue in the project repository.

---

**Happy Task Managing! 📋**
