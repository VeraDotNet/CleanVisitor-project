using CleanVisitor.Application.UseCases.Visitors.Commands.AddVisitor;
using CleanVisitor.Application.UseCases.Visitors.Commands.UpdateVisitor;
using CleanVisitor.Application.UseCases.Visitors.Queries.GetVisitorById;
using CleanVisitor.Application.UseCases.Visitors.Queries.ListVisitors;
using Microsoft.AspNetCore.Mvc;

namespace CleanVisitor.Api.Controllers;

[ApiController]
[Route("api/visitors")]
public class VisitorController : ControllerBase
{
    private readonly AddVisitorHandler _addHandler;
    private readonly ListVisitorsHandler _listHandler;
    private readonly GetVisitorByIdHandler _getByIdHandler;
    private readonly UpdateVisitorHandler _updateHandler;
    public VisitorController(AddVisitorHandler addHandler,
                            ListVisitorsHandler listHandler,
                            GetVisitorByIdHandler getByIdHandler,
                            UpdateVisitorHandler updateHandler)
    {
        _addHandler = addHandler;
        _listHandler = listHandler;
        _getByIdHandler = getByIdHandler;
        _updateHandler = updateHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddVisitorCommand command)
    {
        await _addHandler.Handle(command);
        return Ok("Visitor Sucefully registered");
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var visitors = await _listHandler.Handle(new ListVisitorsQuery());
        return Ok(visitors);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var visitor = await _getByIdHandler.Handle(new GetVisitorByIdQuery{IdVisitor = id});
        return Ok(visitor);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateVisitorCommand command)
    {
        if(id != command.Id)
            return BadRequest("Id mismatch");
        
        await _updateHandler.Handle(command);
        return Ok("Visitor updated successfully");
    }
}