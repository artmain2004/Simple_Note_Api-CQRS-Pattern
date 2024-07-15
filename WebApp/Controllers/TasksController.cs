using WebApp.Command.CreateTask;
using WebApp.Command.DeleteTask;
using WebApp.Command.UpdateTask;
using WebApp.Command.UpdateTaskToCompleted;
using WebApp.Query.GetAllTasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Query.GetTasksByCategory;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTasks()
        {

            var result = await _mediator.Send(new GetAllTasksRequest());

            return Ok(result);
        }
        
        [HttpGet("category")]
        public async Task<ActionResult> GetAllTasksByCategory([FromQuery] string category)
        {

            var result = await _mediator.Send(new GetTasksByCategoryRequest(category));

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewTask([FromBody] CreateTaskRequest createTaskRequest)
        {
            var result =await  _mediator.Send(new CreateTaskRequest(createTaskRequest.title, createTaskRequest.description, createTaskRequest.category));

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask([FromRoute] Guid id, [FromBody] UpdateTaskRequest updateTaskRequest)
        {
            var result = await _mediator.Send(new UpdateTaskRequest(id, updateTaskRequest.title, updateTaskRequest.description, updateTaskRequest.category));

            if (result is  null) return NotFound("Task not found");

            return Ok(result);
        }

        [HttpPut("tocompleted/{id}")]
        public async Task<ActionResult> UpdateTaskToCompleted([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new UpdateTaskToCompletedRequest(id));

            if (result is null) return NotFound("Task not found");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteTaskRequest(id));

            if (result is null) return NotFound("Task not found");

            return Ok(result);
        }

    }
}
