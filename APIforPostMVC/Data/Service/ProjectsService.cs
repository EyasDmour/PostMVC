using APIforPostMVC.Models;
using Microsoft.EntityFrameworkCore;
using APIforPostMVC.Data;

namespace APIforPostMVC.Data.Service;

public class ProjectsService : IProjectsService
{
    private readonly PostMVCContext _context;

    public ProjectsService(PostMVCContext context)
    {
        _context = context;
    }
    public async Task Add(Projects project)
    {
        project.StartDate = DateTime.SpecifyKind(project.StartDate, DateTimeKind.Utc);
        project.EndDate   = DateTime.SpecifyKind(project.EndDate, DateTimeKind.Utc);

        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Projects>> GetAll(int userId)
    {
        var projects = await _context.Projects
            .Where(p => p.OwnerId == userId)
            .ToListAsync();
        return projects;
    }
}
