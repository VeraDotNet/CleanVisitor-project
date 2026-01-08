namespace CleanVisitor.Application.UseCases.Visits.Commands.AddVisit;

public class AddVisitCommand
{
    public int IdVisitor { get; init; } 
    public int IdDepartment { get; init; } 
    public string Purpose { get; init; } = null!;
}
