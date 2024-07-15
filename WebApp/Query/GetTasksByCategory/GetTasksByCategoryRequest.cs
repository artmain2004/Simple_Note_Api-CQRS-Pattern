using MediatR;
using WebApp.Models;

namespace WebApp.Query.GetTasksByCategory
{
    public record GetTasksByCategoryRequest(string category) : IRequest<List<Tasks>>
    {
    }
}
