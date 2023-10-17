using System.ComponentModel.DataAnnotations;

namespace ADLTracker.Models;

public class ContactPrecaution
{
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    public string? Diagram { get; set; }
}