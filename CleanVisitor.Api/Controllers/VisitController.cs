using CleanVisitor.Application.UseCases.Visits.Commands.AddVisit;
using CleanVisitor.Application.UseCases.Visits.Commands.CheckOutVisit;
using CleanVisitor.Application.UseCases.Visits.Queries.ListVisits;
using Microsoft.AspNetCore.Mvc;

namespace CleanVisitor.Api.Controllers;
[ApiController]
[Route("api/Visits")]
public class VisitController : ControllerBase
{
    private readonly AddVisitHandler _addHandler;
    private readonly ListVisitsHandler _listHandler;
    private readonly CheckOutVisitHandler _checkHandler;
    public VisitController(AddVisitHandler addHandler, 
                        ListVisitsHandler listHandler,
                        CheckOutVisitHandler checkHandler)
    {
        _addHandler = addHandler;
        _listHandler = listHandler;
        _checkHandler = checkHandler;
    }
    // POST: api/visits
    [HttpPost]
    public async Task<IActionResult> Post(AddVisitCommand command)
    {
        await _addHandler.Handle(command);
        return Ok("Visit sucessfully registered");
    }
    // GET: api/visits
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var visits = await _listHandler.Handle(new ListVisitsQuery());
        return Ok(visits);
    }
    // PUT: api/visits/{id}/checkout
    [HttpPut("{id}/checkout")]
    public async Task<IActionResult> CheckOut(int id)
    {
        var command = new CheckOutVisitCommand
        {
            IdVisit = id
        };
        await _checkHandler.Handle(command);
        return Ok("Visit successfully checked out");
    }

}
