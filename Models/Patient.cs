using System.ComponentModel.DataAnnotations;
namespace ADLTracker.Models;
public class Patient
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public DateTime DOB { get; set; }
    public int GenderId { get; set; }
    public Gender Gender { get; set; }

    public int Age
    {
        get
        {
            DateTime now = DateTime.Now;
            TimeSpan interval = now - DOB;
            return interval.Days / 365;
        }
    }
}