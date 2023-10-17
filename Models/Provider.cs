using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ADLTracker.Models;
public class Provider
{
    public int Id { get; set; }
    public string IdentityUserId { get; set; }
    public IdentityUser IdentityUser { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [NotMapped]
    public string Email { get; set; }
    [NotMapped]
    public List<string> Roles { get; set; }









}