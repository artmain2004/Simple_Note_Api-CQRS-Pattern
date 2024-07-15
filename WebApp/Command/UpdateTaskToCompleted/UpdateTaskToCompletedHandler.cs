using WebApp.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WebApp.Command.UpdateTaskToCompleted
{
    public class UpdateTaskToCompletedHandler : IRequestHandler<UpdateTaskToCompletedRequest, string>
    {

        private readonly ITaskRepository _taskRepository;

        public UpdateTaskToCompletedHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<string?> Handle(UpdateTaskToCompletedRequest request, CancellationToken cancellationToken)
        {
            var taskById = await _taskRepository.IsTaskExists(request.id);

            if (!taskById) return null;

            await _taskRepository.UpdateTaskToCompletedAsync(request.id);

            return "Task completed successfully";
        }
    }
}
