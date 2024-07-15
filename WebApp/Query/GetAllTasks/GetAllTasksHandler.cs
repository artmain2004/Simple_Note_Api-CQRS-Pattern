using WebApp.Interface;
using WebApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Query.GetAllTasks
{
    public class GetAllTasksHandler : IRequestHandler<GetAllTasksRequest, List<Tasks>>
    {

        private readonly ITaskRepository _taskRepository;

        public GetAllTasksHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<Tasks>> Handle(GetAllTasksRequest request, CancellationToken cancellationToken)
        {
            return await _taskRepository.GetAllTasksAsync();
        }
    }
}
