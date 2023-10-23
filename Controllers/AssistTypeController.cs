using ADLTracker.Data;
using ADLTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ADLTracker.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AssistTypeController : ControllerBase
{
    private ADLTrackerDbContext _dbContext;
    public AssistTypeController(ADLTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAssistTypes()
    {
        List<AssistType> TypeList = _dbContext.AssistTypes.ToList();
        return Ok(TypeList);
    }
}