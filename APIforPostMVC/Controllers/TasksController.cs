using APIforPostMVC.Data.Service;
using APIforPostMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIforPostMVC.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITasksService _service;

    public TasksController(ITasksService service)
    {
        _service = service;
    }

    // GET: api/Tasks
    [HttpGet]
    public async Task<IEnumerable<Tasks>> Get()
    {
        return await _service.GetAll();
    }

    // POST: api/Tasks
    [HttpPost]
    public async Task<IActionResult> Post(Tasks task)
    {
        await _service.Add(task);
        return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
    }
}
