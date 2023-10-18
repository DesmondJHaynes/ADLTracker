using ADLTracker.Data;
using ADLTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADLTracker.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PatientProfileController : ControllerBase
{
    private ADLTrackerDbContext _dbContext;
    public PatientProfileController(ADLTrackerDbContext context)
    {
        _dbContext = context;
    }

    // [Authorize]
    [HttpGet]
    public IActionResult GetPatientList()
    {
        return Ok(
            _dbContext.PatientProfiles
            .Include(pp => pp.Patient)
            .ThenInclude(p => p.Gender)
            .Include(pp => pp.AssistType)
            .Include(pp => pp.ContactPrecaution)
            .OrderBy(pp => pp.RoomNumber)
        );
    }

    // [Authorize]
    [HttpGet("id")]
    public IActionResult GetPatientById(int id)
    {
        PatientProfile found = _dbContext.PatientProfiles
            .Include(pp => pp.Patient)
            .ThenInclude(p => p.Gender)
            .Include(pp => pp.AssistType)
            .Include(pp => pp.ContactPrecaution)
            .SingleOrDefault(pp => pp.Id == id);
        if (found == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(found);
        }
    }
}