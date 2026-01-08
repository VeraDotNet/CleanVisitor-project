using CleanVisitor.Core.Interfaces;
using CleanVisitor.Application.Common.DTos;

namespace CleanVisitor.Application.UseCases.Visitors.Queries.ListVisitors;

public class ListVisitorsHandler
{
    private readonly IVisitorRepository _repository;

    public ListVisitorsHandler(IVisitorRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<VisitorDto>> Handle(ListVisitorsQuery query)
    {
        var visitors = await _repository.GetAllAsync();
        return visitors.Select(v => new VisitorDto
        {
           Id = v.Id,
           Fullname = v.Fullname,
           Phone = v.Phone,
           Email = v.Email
        }).ToList();
    }
}