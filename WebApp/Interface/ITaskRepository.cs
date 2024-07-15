using WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Interface
{
    public interface ITaskRepository
    {
        Task<List<Tasks>> GetAllTasksAsync();

        Task CreateNewTaskAsync(Tasks tasks);

        Task UpdateTaskAsync(Guid taskId, Tasks task);

        Task DeleteTaskAsync(Guid taskId);

        Task UpdateTaskToCompletedAsync(Guid taskId);

        Task<List<Tasks>> GetTasksByCategoryAsync(string category);

        Task<bool>  IsTaskExists(Guid taskId);
    }
}
