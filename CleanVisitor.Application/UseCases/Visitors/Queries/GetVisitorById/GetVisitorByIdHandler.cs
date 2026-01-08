using CleanVisitor.Application.Common.DTos;
using CleanVisitor.Core.Interfaces;

namespace CleanVisitor.Application.UseCases.Visitors.Queries.GetVisitorById;
public class GetVisitorByIdHandler
{
    private readonly IVisitorRepository _repository;
    public GetVisitorByIdHandler(IVisitorRepository repository)
    {
        _repository = repository;
    }
    public async Task<VisitorDto> Handle(GetVisitorByIdQuery query)
    {
        var visitor = await _repository.GetByIdAsync(query.IdVisitor);

        if (visitor == null )
            throw new Exception("Visitor not found");
        
        return new VisitorDto
        {
            Id = visitor.Id,
            Fullname = visitor.Fullname,
            Phone = visitor.Phone,
            Email = visitor.Email
        };
    }
}