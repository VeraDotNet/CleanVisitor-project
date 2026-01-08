using CleanVisitor.Core.Interfaces;

namespace CleanVisitor.Application.UseCases.Visits.Commands.CheckOutVisit;
public class CheckOutVisitHandler
{
    private readonly IVisitRepository _repository;
    public CheckOutVisitHandler(IVisitRepository repository)
    {
        _repository = repository;
    }
    public async Task Handle(CheckOutVisitCommand command)
    {
        var visit = await _repository.GetByIdAsync(command.IdVisit);
        if(visit == null)
            throw new Exception("Visit not found");

        visit.CheckOutTime = DateTime.UtcNow;

        await _repository.UpdateAsync(visit);
    }
}