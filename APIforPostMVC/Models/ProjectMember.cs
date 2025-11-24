using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIforPostMVC.Models;

public class ProjectMember
{
    public int Id { get; set; }

    public int ProjectId { get; set; }
    [ForeignKey("ProjectId")]
    public Projects? Project { get; set; }

    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public Users? User { get; set; }

    [Required]
    public string ProjectRole { get; set; } = "Member"; 
}