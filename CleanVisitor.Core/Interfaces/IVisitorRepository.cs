namespace CleanVisitor.Core.Interfaces;
public interface IVisitorRepository
{
    Task AddAsync(Visitor visitor);
    Task<List<Visitor>> GetAllAsync();
    Task<Visitor?> GetByIdAsync(int Id);
    Task UpdateAsync(Visitor visitor);
    Task DeleteAsync(int Id);
}