using System.ComponentModel.DataAnnotations;

namespace ADLTracker.Models;

public class Registration
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    // public string UserName { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    // public string Address { get; set; }
}