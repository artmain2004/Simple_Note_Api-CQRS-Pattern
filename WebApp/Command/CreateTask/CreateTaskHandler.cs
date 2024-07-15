using WebApp.Interface;
using WebApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Command.CreateTask;

namespace WebApp.Command.CreateTask
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskRequest, string>
    {

        private readonly ITaskRepository _taskRepository;

        public CreateTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<string> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
        {
            
            var newTask = new Tasks(request.title, request.description, request.category);

            await _taskRepository.CreateNewTaskAsync(newTask);

            return "Task added successfully";
        }
    }
}
