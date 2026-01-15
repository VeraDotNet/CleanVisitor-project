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
        else if(visit.CheckOutTime != null)
            throw new Exception("Visit already checked out !");

        visit.CheckOutTime = DateTime.UtcNow;

        //Calcul duration
        visit.duration = visit.CheckOutTime.Value - visit.CheckInTime;
        
        await _repository.UpdateAsync(visit);
    }
}