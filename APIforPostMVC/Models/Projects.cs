using System;
using System.Collections.Generic; // Needed for ICollection
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIforPostMVC.Models;

public class Projects
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    [Required]
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    
    [Required]
    public DateTime EndDate { get; set; } = DateTime.UtcNow.AddMonths(1);
    
    public int Priority { get; set; }

    // --- OWNERSHIP (One-to-Many) ---
    public int OwnerId { get; set; }
    
    [ForeignKey("OwnerId")]
    public Users? Owner { get; set; } // Navigation Property

    // --- MEMBERSHIP (Many-to-Many) ---
    public ICollection<ProjectMember> Members { get; set; } = new List<ProjectMember>();
    
    public override string ToString()
    {
        return $"Project(Id={Id}, Name={Name}, ...)";
    }
}
