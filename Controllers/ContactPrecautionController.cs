using ADLTracker.Data;
using ADLTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ADLTracker.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ContactPrecautionController : ControllerBase
{
    private ADLTrackerDbContext _dbContext;
    public ContactPrecautionController(ADLTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetContactPrecautions()
    {
        List<ContactPrecaution> CPList = _dbContext.ContactPrecautions.ToList();
        return Ok(CPList);
    }
}