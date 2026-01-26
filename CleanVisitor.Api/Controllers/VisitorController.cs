using CleanVisitor.Application.UseCases.Visitors.Commands.AddVisitor;
using CleanVisitor.Application.UseCases.Visitors.Commands.DeleteVisitor;
using CleanVisitor.Application.UseCases.Visitors.Commands.UpdateVisitor;
using CleanVisitor.Application.UseCases.Visitors.Queries.GetVisitorById;
using CleanVisitor.Application.UseCases.Visitors.Queries.ListVisitors;
using Microsoft.AspNetCore.Authorization;
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
    private readonly DeleteVisitorHandler _deleteHandler;
    public VisitorController(AddVisitorHandler addHandler,
                            ListVisitorsHandler listHandler,
                            GetVisitorByIdHandler getByIdHandler,
                            UpdateVisitorHandler updateHandler,
                            DeleteVisitorHandler deleteHandler)
    {
        _addHandler = addHandler;
        _listHandler = listHandler;
        _getByIdHandler = getByIdHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
    }

    [Authorize(Roles = "Receptionist")]
    [HttpPost]
    public async Task<IActionResult> Post(AddVisitorCommand command)
    {
        await _addHandler.Handle(command);
        return Ok("Visitor Sucefully registered");
    }
    // GET: api/visitors
    [Authorize(Roles = "Receptionist, Security")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var visitors = await _listHandler.Handle(new ListVisitorsQuery());
        return Ok(visitors);
    }
    [Authorize(Roles = "Receptionist, Security")]
    // GET: api/visitors/{id}/GetById
    [HttpGet("{id}/GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        var visitor = await _getByIdHandler.Handle(new GetVisitorByIdQuery{IdVisitor = id});
        return Ok(visitor);
    }
    // PUT: api/visitors/{id}/Update
    [Authorize(Roles = "Receptionist")]
    [HttpPut("{id}/Update")]
    public async Task<IActionResult> Update(int id, UpdateVisitorCommand command)
    {
        if(id != command.Id)
            return BadRequest("Id mismatch");
        
        await _updateHandler.Handle(command);
        return Ok("Visitor updated successfully");
    }
    // DELETE: api/visitors/{id}/Delete
    [Authorize(Roles = "Receptionist")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _deleteHandler.Handle(new DeleteVisitorCommand{IdVisitor = id});
        return Ok("Visitor deleted successfully");
    }
}