using CleanVisitor.Core.Interfaces;

namespace CleanVisitor.Application.UseCases.Visitors.Commands.UpdateVisitor;
public class UpdateVisitorHandler
{
    private readonly IVisitorRepository _repository;
    public UpdateVisitorHandler(IVisitorRepository repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateVisitorCommand command)
    {
        var visitor = await _repository.GetByIdAsync(command.Id);
        
        if(visitor == null)
            throw new Exception("Visitor not found");
        
        visitor.Fullname = command.Fullname;
        visitor.Email = command.Email;
        visitor.Phone = command.Phone;

        await _repository.UpdateAsync(visitor);
    }
}