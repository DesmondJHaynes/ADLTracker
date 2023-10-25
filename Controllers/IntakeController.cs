using ADLTracker.Data;
using ADLTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ADLTracker.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class IntakeController : ControllerBase
{
    private ADLTrackerDbContext _dbContext;
    public IntakeController(ADLTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{ppId}")]
    [Authorize]
    public IActionResult Get24HrPatientIntakes(int ppId)
    {
        DateTime now = DateTime.Now;
        DateTime cutOffTime = now.Subtract(new TimeSpan(24, 0, 0));
        List<Intake> intakes = _dbContext.Intakes.Where(i => i.PatientProfileId == ppId && i.TimeRecorded > cutOffTime).ToList();
        return Ok(intakes);
    }

    [HttpPost]
    [Authorize]
    public IActionResult AddIntake(Intake obj)
    {
        Intake newIntake = new Intake()
        {
            PatientProfileId = obj.PatientProfileId,
            ProviderId = obj.ProviderId,
            IntakeAmount = obj.IntakeAmount,
            TimeRecorded = DateTime.Now
        };
        _dbContext.Intakes.Add(newIntake);
        _dbContext.SaveChanges();
        return Created($"/api/intake/{newIntake.Id}", newIntake);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult DeleteIntake(int id)
    {
        Intake found = _dbContext.Intakes.SingleOrDefault(i => i.Id == id);
        if (found == null)
        { return NotFound(); }
        _dbContext.Intakes.Remove(found);
        _dbContext.SaveChanges();
        return NoContent();
    }
}