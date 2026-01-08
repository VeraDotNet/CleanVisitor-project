using CleanVisitor.Core.Interfaces;

namespace CleanVisitor.Application.UseCases.Departments.Commands.AddDepartment;
public class AddDepartmentHandler
{
    private readonly IDepartmentRepository _repository;

    public AddDepartmentHandler(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(AddDepartmentCommand command)
    {
        var department = new Department
        {
            Name = command.Name
        };

        await _repository.AddAsync(department);
    }
}
