using System.Collections.Generic;
using System.Linq;

namespace PostMVC.Models;

public class ProjectTasksViewModel
{
    public int ProjectId { get; set; }
    public IEnumerable<Tasks> Tasks { get; set; } = Enumerable.Empty<Tasks>();
}