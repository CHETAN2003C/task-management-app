using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Data;
using TaskManagementApp.Models;

namespace TaskManagementApp.Services
{
    public class TaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetAllTasksAsync()
        {
            return await _context.Tasks
                .Include(t => t.Category)
                .Include(t => t.Tags)
                .Include(t => t.Comments)
                .Include(t => t.Attachments)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks
                .Include(t => t.Category)
                .Include(t => t.Tags)
                .Include(t => t.Comments)
                .Include(t => t.Attachments)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TaskItem> CreateTaskAsync(TaskItem task)
        {
            task.CreatedAt = DateTime.Now;
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> UpdateTaskAsync(TaskItem task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ToggleTaskCompletionAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return false;

            task.IsCompleted = !task.IsCompleted;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TaskItem>> GetTasksByStatusAsync(bool isCompleted)
        {
            return await _context.Tasks
                .Include(t => t.Category)
                .Include(t => t.Tags)
                .Where(t => t.IsCompleted == isCompleted)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetTasksByPriorityAsync(Priority priority)
        {
            return await _context.Tasks
                .Include(t => t.Category)
                .Include(t => t.Tags)
                .Where(t => t.Priority == priority)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        // Advanced search and filtering
        public async Task<List<TaskItem>> SearchTasksAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllTasksAsync();

            searchTerm = searchTerm.ToLower();
            return await _context.Tasks
                .Include(t => t.Category)
                .Include(t => t.Tags)
                .Where(t => t.Title.ToLower().Contains(searchTerm) ||
                           (t.Description != null && t.Description.ToLower().Contains(searchTerm)))
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetTasksByCategoryAsync(int categoryId)
        {
            return await _context.Tasks
                .Include(t => t.Category)
                .Include(t => t.Tags)
                .Where(t => t.CategoryId == categoryId)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetTasksByTagAsync(int tagId)
        {
            return await _context.Tasks
                .Include(t => t.Category)
                .Include(t => t.Tags)
                .Where(t => t.Tags.Any(tag => tag.Id == tagId))
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetOverdueTasksAsync()
        {
            return await _context.Tasks
                .Include(t => t.Category)
                .Include(t => t.Tags)
                .Where(t => !t.IsCompleted && t.DueDate < DateTime.Now)
                .OrderBy(t => t.DueDate)
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetTasksDueInDaysAsync(int days)
        {
            var targetDate = DateTime.Now.AddDays(days);
            return await _context.Tasks
                .Include(t => t.Category)
                .Include(t => t.Tags)
                .Where(t => !t.IsCompleted && t.DueDate.Date <= targetDate.Date && t.DueDate.Date >= DateTime.Now.Date)
                .OrderBy(t => t.DueDate)
                .ToListAsync();
        }

        public async Task<bool> AddTagToTaskAsync(int taskId, int tagId)
        {
            var task = await _context.Tasks.Include(t => t.Tags).FirstOrDefaultAsync(t => t.Id == taskId);
            var tag = await _context.Tags.FindAsync(tagId);

            if (task == null || tag == null)
                return false;

            if (!task.Tags.Contains(tag))
            {
                task.Tags.Add(tag);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> RemoveTagFromTaskAsync(int taskId, int tagId)
        {
            var task = await _context.Tasks.Include(t => t.Tags).FirstOrDefaultAsync(t => t.Id == taskId);
            var tag = task?.Tags.FirstOrDefault(t => t.Id == tagId);

            if (task == null || tag == null)
                return false;

            task.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return true;
        }

        // Analytics methods
        public async Task<Dictionary<string, int>> GetTaskStatisticsAsync()
        {
            var allTasks = await _context.Tasks.ToListAsync();
            return new Dictionary<string, int>
            {
                ["Total"] = allTasks.Count,
                ["Completed"] = allTasks.Count(t => t.IsCompleted),
                ["Pending"] = allTasks.Count(t => !t.IsCompleted),
                ["Overdue"] = allTasks.Count(t => !t.IsCompleted && t.DueDate < DateTime.Now),
                ["DueToday"] = allTasks.Count(t => !t.IsCompleted && t.DueDate.Date == DateTime.Now.Date),
                ["HighPriority"] = allTasks.Count(t => !t.IsCompleted && t.Priority == Priority.High)
            };
        }

        public async Task<Dictionary<Priority, int>> GetTasksByPriorityCountAsync()
        {
            var tasks = await _context.Tasks.Where(t => !t.IsCompleted).ToListAsync();
            return new Dictionary<Priority, int>
            {
                [Priority.Low] = tasks.Count(t => t.Priority == Priority.Low),
                [Priority.Medium] = tasks.Count(t => t.Priority == Priority.Medium),
                [Priority.High] = tasks.Count(t => t.Priority == Priority.High)
            };
        }

        public async Task<Dictionary<string, int>> GetCompletionTrendAsync(int days = 7)
        {
            var startDate = DateTime.Now.AddDays(-days).Date;
            var tasks = await _context.Tasks
                .Where(t => t.IsCompleted && t.CreatedAt >= startDate)
                .ToListAsync();

            var trend = new Dictionary<string, int>();
            for (int i = 0; i <= days; i++)
            {
                var date = startDate.AddDays(i);
                trend[date.ToString("MMM dd")] = tasks.Count(t => t.CreatedAt.Date == date);
            }

            return trend;
        }
    }
}
