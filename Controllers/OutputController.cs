using ADLTracker.Data;
using ADLTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ADLTracker.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class OutputController : ControllerBase
{
    private ADLTrackerDbContext _dbContext;
    public OutputController(ADLTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{ppId}")]
    [Authorize]
    public IActionResult Get24HrPatientOutputs(int ppId)
    {
        DateTime now = DateTime.Now;
        DateTime cutOffTime = now.Subtract(new TimeSpan(24, 0, 0));
        List<Output> outputs = _dbContext.Outputs.Where(o => o.PatientProfileId == ppId && o.TimeRecorded > cutOffTime).ToList();
        return Ok(outputs);
    }

    [HttpPost]
    [Authorize]
    public IActionResult AddOutput(Output obj)
    {
        Output newOutput = new Output()
        {
            PatientProfileId = obj.PatientProfileId,
            ProviderId = obj.ProviderId,
            OutputAmount = obj.OutputAmount,
            TimeRecorded = DateTime.Now
        };
        _dbContext.Outputs.Add(newOutput);
        _dbContext.SaveChanges();
        return Created($"/api/output/{newOutput.Id}", newOutput);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult DeleteOutput(int id)
    {
        Output found = _dbContext.Outputs.SingleOrDefault(o => o.Id == id);
        if (found == null)
        { return NotFound(); }
        _dbContext.Outputs.Remove(found);
        _dbContext.SaveChanges();
        return NoContent();
    }
}