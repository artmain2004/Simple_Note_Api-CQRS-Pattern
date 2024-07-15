using WebApp.Interface;
using WebApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Command.UpdateTask
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskRequest, string>
    {

        private readonly ITaskRepository _taskRepository;

        public UpdateTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<string?> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
        {
            var taskById = await _taskRepository.IsTaskExists(request.id);

            if (!taskById) return null;

            var updatedTask = new Tasks(request.title, request.description, request.category);

            await _taskRepository.UpdateTaskAsync(request.id, updatedTask);

            return "Task updated successfully";
        }
    }
}
