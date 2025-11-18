using PostMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace PostMVC.Data.Service;

public class ProjectsService : IProjectsService
{
    private readonly PostMVCContext _context;

    public ProjectsService(PostMVCContext context)
    {
        _context = context;
    }
    public Task Add(Projects project)
    {
        _context.Projects.Add(project);
        return _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Projects>> GetAll()
    {
        var projects = await _context.Projects.ToListAsync();
        return projects;
    }
}
