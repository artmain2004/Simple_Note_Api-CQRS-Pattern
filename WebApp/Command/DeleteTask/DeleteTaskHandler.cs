using WebApp.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Command.DeleteTask
{

    public class DeleteTaskHandler : IRequestHandler<DeleteTaskRequest, string>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<string?> Handle(DeleteTaskRequest request, CancellationToken cancellationToken)
        {

            var taskById = await _taskRepository.IsTaskExists(request.taskId);

            if (!taskById) return null;

            await _taskRepository.DeleteTaskAsync(request.taskId);

            return "Task deleted successfully";
        }
    }
}
