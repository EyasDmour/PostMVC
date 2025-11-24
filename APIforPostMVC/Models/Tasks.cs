using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIforPostMVC.Models;

public class Tasks
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Details { get; set; } = string.Empty;

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsCompleted { get; set; } = false;

    [ForeignKey("Projects")]
    public int ProjectId { get; set; }
    
    public override string ToString()
    {
        return $"Task(Id={Id}, Title={Title}, Details={Details}, CreatedAt={CreatedAt}, IsCompleted={IsCompleted}, ProjectId={ProjectId})";
    }
}
