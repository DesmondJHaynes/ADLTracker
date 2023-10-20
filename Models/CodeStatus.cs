using System.ComponentModel.DataAnnotations;

namespace ADLTracker.Models;

public class CodeStatus
{
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    [Required]
    public string Description { get; set; }
}