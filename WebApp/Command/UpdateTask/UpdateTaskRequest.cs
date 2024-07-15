using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  WebApp.Command.UpdateTask
{
    public record UpdateTaskRequest(Guid id, string title, string description, string category) : IRequest<string>
    {
    }
}
