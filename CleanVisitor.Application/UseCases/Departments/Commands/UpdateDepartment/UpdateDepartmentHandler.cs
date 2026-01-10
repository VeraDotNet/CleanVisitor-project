using CleanVisitor.Core.Interfaces;

namespace CleanVisitor.Application.UseCases.Departments.Commands.UpdateDepartment;
public class UpdateDepartmentHandler
{
    private readonly IDepartmentRepository _repository;
    public UpdateDepartmentHandler(IDepartmentRepository repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateDepartmentCommand command)
    {
        var department = await _repository.GetByIdAsync(command.IdDepartment);

        if(department == null)
            throw new Exception("Department not found");
        department.Name = command.Name;

        await _repository.UpdateAsync(department);
    }
}