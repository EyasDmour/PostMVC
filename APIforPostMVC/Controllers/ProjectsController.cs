using APIforPostMVC.Data.Service;
using APIforPostMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIforPostMVC.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectsService _service;

    public ProjectsController(IProjectsService service)
    {
        _service = service;
    }

    // GET: api/Projects
    [HttpGet]
    public async Task<IEnumerable<Projects>> Get()
    {
        return await _service.GetAll();
    }

    // POST: api/Projects
    [HttpPost]
    public async Task<IActionResult> Post(Projects project)
    {
        await _service.Add(project);
        return CreatedAtAction(nameof(Get), new { id = project.Id }, project);
    }
}
