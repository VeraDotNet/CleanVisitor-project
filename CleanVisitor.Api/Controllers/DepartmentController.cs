using CleanVisitor.Application.UseCases.Departments.Commands;
using CleanVisitor.Application.UseCases.Departments.Commands.AddDepartment;
using CleanVisitor.Application.UseCases.Departments.Queries.GetDepartmentById;
using CleanVisitor.Application.UseCases.Departments.Queries.ListDepartments;
using CleanVisitor.Application.UseCases.Departments.Commands.UpdateDepartment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CleanVisitor.Api.Controllers;

[Authorize(Roles = "Admin, Manager")]
[ApiController]
[Route("api/department")]
public class DepartmentController : ControllerBase
{
    private readonly AddDepartmentHandler _addHandler;
    private readonly UpdateDepartmentHandler _updateHandler;
    private readonly DeleteDepartmentHandler _deleteHandler;
    private readonly ListDepartmentsHandler _listHandler;
    private readonly GetDepartmentByIdHandler _getByIdHandler;
    public DepartmentController(AddDepartmentHandler addHandler,
                                ListDepartmentsHandler listHandler,
                                GetDepartmentByIdHandler getByIdHandler,
                                UpdateDepartmentHandler updateHandler,
                                DeleteDepartmentHandler deleteHandler)
    {
        _addHandler = addHandler;
        _listHandler = listHandler;
        _getByIdHandler = getByIdHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddDepartmentCommand command)
    {
        await _addHandler.Handle(command);
        return Ok("Department sucefully registered");
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var departments = await _listHandler.Handle(new ListDepartmentsQuery());
        return Ok(departments);
    }   
    // GET: api/Departments/{id}/GetById
    [HttpGet("{id}/GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        var department = await _getByIdHandler.Handle(new GetDepartementByIdQuery{IdDepartment = id});
        return Ok(department);
    }
    // PUT: api/departmehnts/{id}/Update
    [HttpPut("{id}/Update")]
    public async Task<IActionResult> Update(int id, UpdateDepartmentCommand command)
    {
        if(id != command.IdDepartment)
            return BadRequest("Id mismatch");
        
        await _updateHandler.Handle(command);
        return Ok("Department updated successfully");
    }
    // DELETE: api/departments/{id}/Delete
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _deleteHandler.Handle(new DeleteDepartmentCommand{IdDepartment = id});
        return Ok("Department deleted successfully");
    }
}