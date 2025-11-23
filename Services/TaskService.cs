using TaskManagementApp.Models;

namespace TaskManagementApp.Services;

public class TaskService
{
    private readonly List<TaskItem> _tasks = new();
    private int _nextId = 1;

    public TaskService()
    {
        // Add some sample tasks
        _tasks.Add(new TaskItem
        {
            Id = _nextId++,
            Title = "Complete project documentation",
            Description = "Write comprehensive documentation for the task management app",
            Status = Models.TaskStatus.InProgress,
            Priority = Models.TaskPriority.High,
            DueDate = DateTime.Now.AddDays(3),
            CreatedDate = DateTime.Now.AddDays(-2)
        });
        
        _tasks.Add(new TaskItem
        {
            Id = _nextId++,
            Title = "Review code changes",
            Description = "Review pull requests from team members",
            Status = Models.TaskStatus.Pending,
            Priority = Models.TaskPriority.Medium,
            DueDate = DateTime.Now.AddDays(1),
            CreatedDate = DateTime.Now.AddDays(-1)
        });
        
        _tasks.Add(new TaskItem
        {
            Id = _nextId++,
            Title = "Fix bug in authentication",
            Description = "Users reporting login issues",
            Status = Models.TaskStatus.Pending,
            Priority = Models.TaskPriority.Critical,
            DueDate = DateTime.Now.AddHours(12),
            CreatedDate = DateTime.Now
        });
    }

    public List<TaskItem> GetAllTasks()
    {
        return _tasks.OrderByDescending(t => t.CreatedDate).ToList();
    }

    public TaskItem? GetTaskById(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public TaskItem CreateTask(TaskItem task)
    {
        task.Id = _nextId++;
        task.CreatedDate = DateTime.Now;
        _tasks.Add(task);
        return task;
    }

    public bool UpdateTask(TaskItem task)
    {
        var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
        if (existingTask == null)
            return false;

        existingTask.Title = task.Title;
        existingTask.Description = task.Description;
        existingTask.Status = task.Status;
        existingTask.Priority = task.Priority;
        existingTask.DueDate = task.DueDate;
        return true;
    }

    public bool DeleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
            return false;

        _tasks.Remove(task);
        return true;
    }

    public List<TaskItem> GetTasksByStatus(Models.TaskStatus status)
    {
        return _tasks.Where(t => t.Status == status)
                     .OrderByDescending(t => t.CreatedDate)
                     .ToList();
    }

    public List<TaskItem> GetTasksByPriority(Models.TaskPriority priority)
    {
        return _tasks.Where(t => t.Priority == priority)
                     .OrderByDescending(t => t.CreatedDate)
                     .ToList();
    }
}
