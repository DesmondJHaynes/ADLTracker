using System.ComponentModel.DataAnnotations;

namespace ADLTracker.Models;

public class AssistType
{
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    [Required]
    public string Simple { get; set; }
}