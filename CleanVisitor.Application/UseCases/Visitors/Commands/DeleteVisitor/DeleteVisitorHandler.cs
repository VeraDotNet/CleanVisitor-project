using System.Runtime.InteropServices;
using CleanVisitor.Core.Interfaces;

namespace CleanVisitor.Application.UseCases.Visitors.Commands.DeleteVisitor;
public class DeleteVisitorHandler
{
    private readonly IVisitorRepository _repository;
    public DeleteVisitorHandler(IVisitorRepository repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteVisitorCommand command)
    {
        var visitor = await _repository.GetByIdAsync(command.IdVisitor);

        if(visitor == null)
        {
            throw new Exception("Visitor not found");
        }
        else if (visitor.Visits.Any())
        {
            throw new Exception("Cannot delete visitor with visits");
        }

        await _repository.DeleteAsync(visitor.Id);
    }
}