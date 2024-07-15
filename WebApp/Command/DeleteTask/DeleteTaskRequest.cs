using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Command.DeleteTask
{
    public record DeleteTaskRequest(Guid taskId) : IRequest<string>
    {
    }
}
