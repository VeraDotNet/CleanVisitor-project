namespace CleanVisitor.Application.UseCases.Visitors.Commands.AddVisitor;

public class AddVisitorCommand
{
    public string Fullname {get; init;} = null!;
    public string Email {get; init;} = null!;
    public string Phone {get; init;} = null!;
}