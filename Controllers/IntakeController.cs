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

    [HttpGet]
    [Authorize]
    public IActionResult GetIntakes()
    {
        List<Intake> intakes = _dbContext.Intakes.ToList();
        return Ok(intakes);
    }

    [HttpPost]
    [Authorize]
    public IActionResult AddIntake(Intake obj)
    {
        Intake newIntake = new Intake()
        {
            PatientProfileId = obj.PatientProfileId,
            IntakeAmount = obj.IntakeAmount,
            TimeRecorded = DateTime.Now
        };
        _dbContext.Intakes.Add(newIntake);
        _dbContext.SaveChanges();
        return Created($"/api/intake/{newIntake.Id}", newIntake);
    }
}