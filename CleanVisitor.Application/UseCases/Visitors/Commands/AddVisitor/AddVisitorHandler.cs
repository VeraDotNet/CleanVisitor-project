using CleanVisitor.Core.Interfaces;

namespace CleanVisitor.Application.UseCases.Visitors.Commands.AddVisitor;
public class AddVisitorHandler
{
    private readonly IVisitorRepository _repository;

    public AddVisitorHandler(IVisitorRepository repository)
    {
        _repository = repository;
    }
    public async Task Handle(AddVisitorCommand command)
    {
        var visitor = new Visitor
        {
            Fullname = command.Fullname,
            Phone = command.Phone,
            Email = command.Email
        };

        await _repository.AddAsync(visitor);
    }
}