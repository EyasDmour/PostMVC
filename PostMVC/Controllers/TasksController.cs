using Microsoft.AspNetCore.Mvc;
using PostMVC.Data.Service;
using PostMVC.Models;

namespace PostMVC.Controllers
{
    [Route("Tasks")]
    public class TasksController : Controller
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService) => _tasksService = tasksService;

        [HttpGet("")]
        public async Task<ActionResult> Index()
        {
            var tasks = await _tasksService.GetAll();
            return View(tasks);
        }

        [HttpGet("Create")]
        public ActionResult Create([FromQuery] int? projectId)
        {
            var model = new Tasks();
            if (projectId.HasValue)
            {
                model.ProjectId = projectId.Value;
            }
            return View(model);
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Tasks task)
        {
            if (!ModelState.IsValid) return View(task);
            await _tasksService.Add(task);
            return RedirectToAction(nameof(Index));
        }
    }
}
