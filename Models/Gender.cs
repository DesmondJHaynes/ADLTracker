using System.ComponentModel.DataAnnotations;

namespace ADLTracker.Models;

public class Gender
{
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    [Required]
    public string Simple { get; set; }
}