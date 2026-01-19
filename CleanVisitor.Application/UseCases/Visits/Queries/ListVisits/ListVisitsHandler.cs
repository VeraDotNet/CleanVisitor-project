using CleanVisitor.Application.Common.DTos;
using CleanVisitor.Core.Interfaces;

namespace CleanVisitor.Application.UseCases.Visits.Queries.ListVisits;
public class ListVisitsHandler
{
    private readonly IVisitRepository _repository;
    public ListVisitsHandler(IVisitRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<VisitDto>> Handle(ListVisitsQuery query)
    {
        var visits = await _repository.GetAllAsync();
        return visits.Select(v => new VisitDto
        {
            Id = v.Id,
            VisitorName = v.Visitor.Fullname,
            DepartmentName = v.Department.Name,
            Purpose = v.Purpose,
            CheckInTime = v.CheckInTime,
            CheckOutTime = v.CheckOutTime,
            Duration = v.Duration
        }).ToList();
    }
}

