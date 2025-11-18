using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostMVC.Data;
using PostMVC.Models;

namespace PostMVC.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly PostMVCContext _context;

        public ProjectsController(PostMVCContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            var projects = await _context.Projects.ToListAsync();
            return View(projects);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Create(Projects project)
        {
            if (ModelState.IsValid)
            {
                project.StartDate = DateTime.SpecifyKind(project.StartDate, DateTimeKind.Utc);
                project.EndDate   = DateTime.SpecifyKind(project.EndDate, DateTimeKind.Utc);

                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(project);
        }

    }
}
