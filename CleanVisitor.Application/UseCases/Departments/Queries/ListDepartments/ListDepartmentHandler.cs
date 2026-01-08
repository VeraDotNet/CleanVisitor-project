using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using CleanVisitor.Application.Common.DTos;
using CleanVisitor.Core.Interfaces;

namespace CleanVisitor.Application.UseCases.Departments.Queries.ListDepartments;
public class ListDepartmentsHandler
{
    private readonly IDepartmentRepository _repository;

    public ListDepartmentsHandler(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<DepartmentDto>> Handle(ListDepartmentsQuery query)
    {
        var departments = await _repository.GetAllAsync();
        return departments.Select(d => new DepartmentDto
        {
            Id = d.Id,
            Name = d.Name
        }).ToList();
    }
}
