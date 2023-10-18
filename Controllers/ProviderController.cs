using ADLTracker.Data;
using ADLTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADLTracker.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ProviderController : ControllerBase
{
    private ADLTrackerDbContext _dbContext;
    public ProviderController(ADLTrackerDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Get()
    {
        return Ok(_dbContext.Providers.ToList());
    }

    [HttpGet("withroles")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetWithRoles()
    {
        return Ok(_dbContext.Providers.Include(up => up.IdentityUser)
            .Select(up => new Provider
            {
                Id = up.Id,
                FirstName = up.FirstName,
                LastName = up.LastName,
                Email = up.IdentityUser.Email,
                IdentityUserId = up.IdentityUserId,
                Roles = _dbContext.UserRoles
                .Where(ur => ur.UserId == up.IdentityUserId)
                .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
                .ToList()
            }));
    }

    [HttpPost("promote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Promote(string id)
    {
        IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");
        // This will create a new row in the many-to-many UserRoles table.
        _dbContext.UserRoles.Add(new IdentityUserRole<string>
        {
            RoleId = role.Id,
            UserId = id
        });
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPost("demote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Demote(string id)
    {
        IdentityRole role = _dbContext.Roles
            .SingleOrDefault(r => r.Name == "Admin");
        IdentityUserRole<string> userRole = _dbContext
            .UserRoles
            .SingleOrDefault(ur =>
                ur.RoleId == role.Id &&
                ur.UserId == id);

        _dbContext.UserRoles.Remove(userRole);
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        Provider found = _dbContext
        .Providers
        .Include(p => p.IdentityUser)
        .FirstOrDefault(p => p.Id == id);
        if (found == null)
        { return NotFound(); }
        return Ok(found);
    }
}