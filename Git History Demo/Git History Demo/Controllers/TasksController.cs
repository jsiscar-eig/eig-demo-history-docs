
using Microsoft.AspNetCore.Mvc;
using Git_History_Demo.Models;

namespace Git_History_Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private static readonly List<TaskItem> Tasks = new()
    {
        new TaskItem
        {
            Id = 1,
            Title = "Set up GitHub",
            Description = "Create the project repository",
            IsCompleted = true
        },
        new TaskItem
        {
            Id = 2,
            Title = "Generate API documentation",
            Description = "Automate OpenAPI generation",
            IsCompleted = false
        }
    };

    [HttpGet]
    public ActionResult<List<TaskItem>> GetTasks()
    {
        return Ok(Tasks);
    }

    [HttpGet("{id}")]
    public ActionResult<TaskItem> GetTask(int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
            return NotFound();

        return Ok(task);
    }

    [HttpPost]
    public ActionResult<TaskItem> CreateTask(TaskItem task)
    {
        task.Id = Tasks.Count == 0 ? 1 : Tasks.Max(t => t.Id) + 1;

        Tasks.Add(task);

        return CreatedAtAction(
            nameof(GetTask),
            new { id = task.Id },
            task
        );
    }
}
