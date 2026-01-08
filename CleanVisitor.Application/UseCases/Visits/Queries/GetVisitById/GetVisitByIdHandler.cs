using CleanVisitor.Application.Common.DTos;
using CleanVisitor.Core.Interfaces;

namespace CleanVisitor.Application.UseCases.Visits.Queries.GetVisitById;
public class GetVisitByIdHandler
{
    private readonly IVisitRepository _repository;
    public GetVisitByIdHandler(IVisitRepository repository)
    {
        _repository = repository;
    }
    public async Task<VisitDto> Handle(GetVisitByIdQuery query)
    {
        var visit = await _repository.GetByIdAsync(query.IdVisit);

        if(visit == null)
            throw new Exception("Visit not found");

        return new VisitDto
        {
            Id = visit.Id,
            VisitorName = visit.Visitor.Fullname,
            DepartmentName = visit.Department.Name,
            Purpose = visit.Purpose,
            CheckInTime = visit.CheckInTime,
            CheckOutTime = visit.CheckOutTime
        };
    }
}