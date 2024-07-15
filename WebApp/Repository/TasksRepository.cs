using WebApp.Models;
using WebApp.Interface;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;



namespace WebApp.Repository
{
    public class TasksRepository : ITaskRepository
    {

        private readonly TaskManagerDbContext _context;

        public TasksRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task CreateNewTaskAsync(Tasks tasks)
        {
            await _context.AddAsync(tasks);

            await _context.SaveChangesAsync();

            
        }

        public async Task DeleteTaskAsync(Guid taskId)
        {

            await _context.Tasks.Where(t => t.Id == taskId).ExecuteDeleteAsync();

            
        }

        public async Task<List<Tasks>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<List<Tasks>> GetTasksByCategoryAsync(string category)
        {
            return await _context.Tasks.Where(t => t.Category == category).ToListAsync();
        }

        public async Task<bool> IsTaskExists(Guid taskId)
        {
            return await _context.Tasks.AnyAsync(t => t.Id == taskId);
        }

        public async Task UpdateTaskAsync(Guid taskId, Tasks task)
        {
            await _context.Tasks
                .Where(t => t.Id == taskId)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(t => t.Title, task.Title)
                    .SetProperty(t => t.Description, task.Description)
                    
                 );

            


        }

        public async Task UpdateTaskToCompletedAsync(Guid taskId)
        {
            await _context.Tasks
                .Where(t => t.Id == taskId)
                .ExecuteUpdateAsync(s => s

                .SetProperty(t => t.IsCompleted, true)

                );

            
        }
    }
}
