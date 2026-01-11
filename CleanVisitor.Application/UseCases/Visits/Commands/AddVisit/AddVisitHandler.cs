using System.Reflection.Metadata;
using CleanVisitor.Core.Interfaces;

namespace CleanVisitor.Application.UseCases.Visits.Commands.AddVisit;

public class AddVisitHandler
{
    private readonly IVisitRepository _repository;
    private readonly IVisitorRepository _visitorRepository;
    public AddVisitHandler(IVisitRepository repository,
                            IVisitorRepository visitorRepository)
    {
        _repository = repository;
        _visitorRepository = visitorRepository;
    }
    public async Task Handle(AddVisitCommand command)
    {
        //Verify if the visitor exist
        var visitor = await _visitorRepository.GetByIdAsync(command.IdVisitor);
        if(visitor == null)
            throw new Exception("Visitor not found");

        //verify the visitor hasn't any visit on
        //var activeVisit = await _visitorRepository.G
        var visit = new Visit
        {
            IdVisitor = command.IdVisitor,
            IdDepartment = command.IdDepartment,
            Purpose = command.Purpose,
            CheckInTime = DateTime.UtcNow
        };
        await _repository.AddAsync(visit);
    }
}