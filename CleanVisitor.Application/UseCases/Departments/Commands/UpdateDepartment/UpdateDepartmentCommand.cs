namespace CleanVisitor.Application.UseCases.Departments.Commands.UpdateDepartment;
public class UpdateDepartmentCommand
{
    public int IdDepartment {get;set;}
    public string Name {get; set;} = null!;
}