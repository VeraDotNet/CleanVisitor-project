using System.Reflection.Metadata;
using CleanVisitor.Core.Interfaces;

namespace CleanVisitor.Application.UseCases.Visits.Commands.AddVisit;

public class AddVisitHandler
{
    private readonly IVisitRepository _repository;
    public AddVisitHandler(IVisitRepository repository)
    {
        _repository = repository;
    }
    public async Task Handle(AddVisitCommand command)
    {
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