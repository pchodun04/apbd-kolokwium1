namespace ConsoleApp1.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsoleApp1.Services;

[Route("api/[controller]")]
[ApiController]
public class VisitController : ControllerBase
{
    private readonly IVisitService _visitService;
    
    public VisitController(IVisitService visitService){
        _visitService = visitService;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTrip(int id)
    {
        var trip = await _visitService.GetVisits(id);
        return Ok(trip);
    }
}

