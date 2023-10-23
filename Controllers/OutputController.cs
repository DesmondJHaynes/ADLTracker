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

    [HttpGet]
    [Authorize]
    public IActionResult GetOutputs()
    {
        List<Output> outputs = _dbContext.Outputs.ToList();
        return Ok(outputs);
    }

    [HttpPost]
    [Authorize]
    public IActionResult AddOutput(Output obj)
    {
        Output newOutput = new Output()
        {
            PatientProfileId = obj.PatientProfileId,
            OutputAmount = obj.OutputAmount,
            TimeRecorded = DateTime.Now
        };
        _dbContext.Outputs.Add(newOutput);
        _dbContext.SaveChanges();
        return Created($"/api/output/{newOutput.Id}", newOutput);
    }
}