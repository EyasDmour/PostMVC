using Microsoft.AspNetCore.Mvc;
using PostMVC.Data;
using PostMVC.Data.Service;
using PostMVC.Models;

namespace PostMVC.Controllers
{
    [Route("Tasks")]
    public class TasksController : Controller
    {
        private readonly ITasksService _tasksService;
        private readonly PostMVCContext _context;

        public TasksController(ITasksService tasksService, PostMVCContext context)
        {
            _tasksService = tasksService;
            _context = context;
        }

        [HttpGet("")]
        public ActionResult Index(int? projectId)
        {
            ViewBag.Projects = _context.Projects.ToList();

            if (projectId == null)
            {
                return View(new List<Tasks>());
            }

            var tasks = _context.Tasks.Where(t => t.ProjectId == projectId).ToList();
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
