using CleanVisitor.Core.Interfaces;

namespace CleanVisitor.Application.UseCases.Departments.Commands;
public class DeleteDepartmentHandler
{
    private readonly IDepartmentRepository _repository;
    public DeleteDepartmentHandler(IDepartmentRepository repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteDepartmentCommand command)
    {
        var department = await _repository.GetByIdAsync(command.IdDepartment);

        if(department == null)
            throw new Exception("Department not found");
        else if(department.Visits.Any())
            throw new Exception("Cannot delete department with visits !");
        
        await _repository.DeleteAsync(department.Id);
    }
}