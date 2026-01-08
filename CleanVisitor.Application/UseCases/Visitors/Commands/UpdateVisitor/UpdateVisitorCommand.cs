namespace CleanVisitor.Application.UseCases.Visitors.Commands.UpdateVisitor;
public class UpdateVisitorCommand
{
    public int Id { get; set; }
    public string Fullname { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
}