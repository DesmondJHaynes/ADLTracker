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

    [HttpGet]
    [Authorize]
    public IActionResult GetPatientList()
    {
        return Ok(
            _dbContext.PatientProfiles
            .Include(pp => pp.Patient)
            .ThenInclude(p => p.Gender)
            .Include(pp => pp.AssistType)
            .Include(pp => pp.ContactPrecaution)
            .Include(pp => pp.CodeStatus)
            .Include(pp => pp.Outputs)
            .Include(pp => pp.Intakes)
            .OrderBy(pp => pp.RoomNumber)
        );
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetPatientById(int id)
    {
        PatientProfile found = _dbContext.PatientProfiles
            .Include(pp => pp.Patient)
            .ThenInclude(p => p.Gender)
            .Include(pp => pp.AssistType)
            .Include(pp => pp.ContactPrecaution)
            .Include(pp => pp.CodeStatus)
            .Include(pp => pp.Outputs)
            .Include(pp => pp.Intakes)
            .SingleOrDefault(pp => pp.Id == id);

        if (found == null)
        { return NotFound(); }

        return Ok(found);
    }


    [HttpPut("{id}/weight")]
    [Authorize]
    public IActionResult UpdateWeight(int id, PatientProfile obj)
    {
        if (obj.Id != id)
        { return BadRequest(); }

        PatientProfile found = _dbContext.PatientProfiles.SingleOrDefault(pp => pp.Id == id);

        if (found == null)
        { return NotFound(); }

        found.Weight = obj.Weight;
        _dbContext.SaveChanges();
        return Ok(found.Weight);
    }

    [HttpPut("{id}/bath")]
    [Authorize]
    public IActionResult UpdateLastBath(int id, PatientProfile obj)
    {
        if (obj.Id != id)
        { return BadRequest(); }

        PatientProfile found = _dbContext.PatientProfiles.SingleOrDefault(pp => pp.Id == id);

        if (found == null)
        { return NotFound(); }

        found.LastBath = obj.LastBath;
        _dbContext.SaveChanges();
        return Ok(found.LastBath);
    }

    [HttpPut("{id}/bm")]
    [Authorize]
    public IActionResult UpdateLastBM(int id, PatientProfile obj)
    {
        if (obj.Id != id)
        { return BadRequest(); }

        PatientProfile found = _dbContext.PatientProfiles.SingleOrDefault(pp => pp.Id == id);

        if (found == null)
        { return NotFound(); }

        found.LastBM = obj.LastBM;
        _dbContext.SaveChanges();
        return Ok(found.LastBM);
    }

    [HttpPut("{id}/telemetry")]
    [Authorize]
    public IActionResult UpdateTelemetry(int id, PatientProfile obj)
    {
        if (obj.Id != id)
        { return BadRequest(); }

        PatientProfile found = _dbContext.PatientProfiles.SingleOrDefault(pp => pp.Id == id);

        if (found == null)
        { return NotFound(); }

        found.Telemetry = obj.Telemetry;
        found.TelemetryNumber = obj.TelemetryNumber;
        _dbContext.SaveChanges();
        return Ok(found.LastBM);
    }
}