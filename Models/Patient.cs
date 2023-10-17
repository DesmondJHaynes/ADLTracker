using System.ComponentModel.DataAnnotations;
namespace ADLTracker.Models;
public class Patient
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public DateOnly DOB { get; set; }
    public int GenderId { get; set; }
    public Gender Gender { get; set; }
}