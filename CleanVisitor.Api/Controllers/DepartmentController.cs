using CleanVisitor.Application.UseCases.Departments.Commands.AddDepartment;
using CleanVisitor.Application.UseCases.Departments.Queries.ListDepartments;
using Microsoft.AspNetCore.Mvc;

namespace CleanVisitor.Api.Controllers;

[ApiController]
[Route("api/department")]
public class DepartmentController : ControllerBase
{
    private readonly AddDepartmentHandler _addHandler;
    private readonly ListDepartmentsHandler _listHandler;
    public DepartmentController(AddDepartmentHandler addHandler,
                                ListDepartmentsHandler listHandler)
    {
        _addHandler = addHandler;
        _listHandler = listHandler;
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
}