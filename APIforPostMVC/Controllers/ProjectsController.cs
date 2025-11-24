using System.Security.Claims;
using APIforPostMVC.Data.Service;
using APIforPostMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace APIforPostMVC.Controllers;

[Authorize]
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
        var userId = GetUserId();
        return await _service.GetAll(userId);
    }

    // POST: api/Projects
    [HttpPost]
    public async Task<IActionResult> Post(Projects project)
    {
        var userId = GetUserId();
        project.OwnerId = userId;
        
        await _service.Add(project);
        return CreatedAtAction(nameof(Get), new { id = project.Id }, project);
    }

    private int GetUserId()
    {
        var userIdClaim = User.FindFirst(JwtRegisteredClaimNames.Sub) ?? User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
        {
            return userId;
        }
        throw new UnauthorizedAccessException("User ID not found in token.");
    }
}
