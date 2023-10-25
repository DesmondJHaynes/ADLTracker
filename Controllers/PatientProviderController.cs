using ADLTracker.Data;
using ADLTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ADLTracker.Controllers;

[ApiController]
[Route("/api/[controller]")]


public class PatientProviderController : ControllerBase
{
    private ADLTrackerDbContext _dbContext;
    public PatientProviderController(ADLTrackerDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetPatientProviders()
    {

        List<PatientProvider> patientProviders = _dbContext
        .PatientProviders.Include(pp => pp.Provider)
        .ToList();

        return Ok(patientProviders);
    }

    [HttpPost]
    [Authorize]
    public IActionResult CreatePatPro(PatientProvider ppObj)
    {

        PatientProvider theOne = _dbContext.PatientProviders.SingleOrDefault(pp => pp.PatientProfileId == ppObj.PatientProfileId && pp.ProviderId == ppObj.ProviderId);

        if (theOne != null)
        {
            return BadRequest();
        }

        PatientProvider newPatPro = new PatientProvider()
        {
            PatientProfileId = ppObj.PatientProfileId,
            ProviderId = ppObj.ProviderId,
        };

        _dbContext.PatientProviders.Add(newPatPro);
        _dbContext.SaveChanges();
        return Created("api/PatientProvider/{id}", newPatPro);
    }

    [HttpDelete("{patientId}")]
    [Authorize]
    public IActionResult DeletePatPro(int patientId, int userId)
    {
        PatientProvider theOne = _dbContext.PatientProviders.SingleOrDefault(pp => pp.PatientProfileId == patientId && pp.ProviderId == userId);
        if (theOne == null)
        { return NotFound(); }

        _dbContext.Remove(theOne);
        _dbContext.SaveChanges();


        return NoContent();
    }

}
