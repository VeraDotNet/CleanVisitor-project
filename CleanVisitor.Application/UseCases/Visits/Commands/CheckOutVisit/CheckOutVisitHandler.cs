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
        var activeVisit = await _repository.GetActiveVisitByVisitorIdAsync(command.IdVisitor);

        //Check-in verification
        if(activeVisit == null)
            throw new Exception("This visitor has no active visit");

        //Unique check-out verification
        // if(activeVisit.CheckOutTime != null)
            // throw new Exception("Visit already checked out !");

        activeVisit.CheckOutTime = DateTime.UtcNow;

        //Calcul duration
        activeVisit.Duration = activeVisit.CheckOutTime.Value - activeVisit.CheckInTime;
        
        await _repository.UpdateAsync(activeVisit);
    }
}