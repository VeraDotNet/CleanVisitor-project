using CleanVisitor.Application.UseCases.Visits.Commands.AddVisit;
using CleanVisitor.Application.UseCases.Visits.Commands.CheckOutVisit;
using CleanVisitor.Application.UseCases.Visits.Queries.GetVisitById;
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
    private readonly GetVisitByIdHandler _getByIdHandler;
    public VisitController(AddVisitHandler addHandler, 
                        ListVisitsHandler listHandler,
                        CheckOutVisitHandler checkHandler,
                        GetVisitByIdHandler getByIdHandler)
    {
        _addHandler = addHandler;
        _listHandler = listHandler;
        _checkHandler = checkHandler;
        _getByIdHandler = getByIdHandler;
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
            IdVisitor = id
        };
        await _checkHandler.Handle(command);
        return Ok("Visit successfully checked out");
    }
    // GET: api/visits/{id}/GetById
    [HttpGet("{id}/GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        var visit = await _getByIdHandler.Handle(new GetVisitByIdQuery{IdVisit = id});
        return Ok(visit);
    }
}