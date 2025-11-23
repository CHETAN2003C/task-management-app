# Task Management App

A modern **Blazor Server** web application for managing tasks efficiently. Built with .NET 10 and Bootstrap 5, this application provides a clean and intuitive interface for organizing and tracking your work.

## Features

### ✨ Core Functionality
- **Create Tasks**: Add new tasks with titles, descriptions, priorities, and due dates
- **Edit Tasks**: Update existing tasks with a user-friendly modal interface
- **Delete Tasks**: Remove tasks with confirmation dialog
- **Status Management**: Toggle task status between Pending, In Progress, and Completed
- **Priority Levels**: Assign priority levels (Low, Medium, High, Critical) with visual indicators

### 🔍 Filtering & Search
- **Status Filters**: Quick filter buttons to view tasks by status
- **Real-time Search**: Search tasks by title or description
- **Visual Badges**: Color-coded badges for status and priority

### 🎨 Modern UI/UX
- **Responsive Design**: Works seamlessly on desktop and mobile devices
- **Card-based Layout**: Clean, organized task cards with hover effects
- **Modal Dialogs**: Intuitive modals for creating and editing tasks
- **Bootstrap 5**: Modern styling with custom enhancements

## Technology Stack

- **.NET 10**: Latest .NET platform
- **Blazor Server**: Interactive server-side rendering
- **C#**: Backend logic and service layer
- **Bootstrap 5**: Responsive UI framework
- **Bootstrap Icons**: Icon library

## Getting Started

### Prerequisites
- .NET 10 SDK or later

### Running the Application

1. Clone the repository:
```bash
git clone https://github.com/CHETAN2003C/task-management-app.git
cd task-management-app
```

2. Build the project:
```bash
dotnet build
```

3. Run the application:
```bash
dotnet run
```

4. Open your browser and navigate to `http://localhost:5000` (or the URL shown in the console)

## Project Structure

```
TaskManagementApp/
├── Components/
│   ├── Layout/          # Layout components (MainLayout, NavMenu)
│   └── Pages/           # Razor pages (Home, Tasks, etc.)
├── Models/              # Data models (TaskItem, TaskStatus, TaskPriority)
├── Services/            # Business logic (TaskService)
├── wwwroot/             # Static files (CSS, JavaScript)
└── Program.cs           # Application entry point
```

## Usage

### Creating a Task
1. Click the **"New Task"** button
2. Fill in the task details:
   - Title (required)
   - Description
   - Status (Pending, In Progress, Completed)
   - Priority (Low, Medium, High, Critical)
   - Due Date (optional)
3. Click **"Create"** to add the task

### Managing Tasks
- **Edit**: Click the "Edit" button on any task card to modify it
- **Status**: Click the "Status" button to cycle through status states
- **Delete**: Click the "Delete" button and confirm to remove a task

### Filtering Tasks
- Use the filter buttons to view tasks by status (All, Pending, In Progress, Completed)
- Use the search box to find tasks by title or description

## Screenshots

### Home Page
![Home Page](https://github.com/user-attachments/assets/fe3d71f5-a768-4c82-8184-51ce4d93b2d0)

### Tasks Page
![Tasks Page](https://github.com/user-attachments/assets/3a2e106c-cd06-4350-b449-e04e217ccc09)

### Create Task Modal
![Create Task Modal](https://github.com/user-attachments/assets/8d98cf04-ae9a-4c62-bb2f-3d7b4b8d9b9e)

### Task Management in Action
![Task Management](https://github.com/user-attachments/assets/b6013813-507d-423d-a47e-4ba667f068c0)

## License

This project is open source and available under the MIT License.
