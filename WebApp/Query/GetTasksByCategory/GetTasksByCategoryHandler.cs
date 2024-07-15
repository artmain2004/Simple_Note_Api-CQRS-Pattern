using MediatR;
using WebApp.Interface;
using WebApp.Models;

namespace WebApp.Query.GetTasksByCategory
{
    public class GetTasksByCategoryHandler : IRequestHandler<GetTasksByCategoryRequest, List<Tasks>>
    {


        private readonly ITaskRepository _taskRepository;

        public GetTasksByCategoryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<Tasks>> Handle(GetTasksByCategoryRequest request, CancellationToken cancellationToken)
        {
            return await _taskRepository.GetTasksByCategoryAsync(request.category);
        }
    }
}
