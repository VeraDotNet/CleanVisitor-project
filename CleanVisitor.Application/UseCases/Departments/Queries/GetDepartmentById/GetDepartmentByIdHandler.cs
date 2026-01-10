using CleanVisitor.Application.Common.DTos;
using CleanVisitor.Core.Interfaces;

namespace CleanVisitor.Application.UseCases.Departments.Queries.GetDepartmentById;
public class GetDepartmentByIdHandler
{
    private readonly IDepartmentRepository _repository;
    public GetDepartmentByIdHandler(IDepartmentRepository repository)
    {
        _repository = repository;
    }
    public async Task<DepartmentDto> Handle(GetDepartementByIdQuery query)
    {
        var department = await _repository.GetByIdAsync(query.IdDepartment);

        if(department == null)
            throw new Exception("Department not found");
        return new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name
        };
    }
}