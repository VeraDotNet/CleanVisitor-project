namespace CleanVisitor.Core.Interfaces;

public interface IVisitRepository
{
    Task AddAsync(Visit visit);
    Task<List<Visit>> GetAllAsync();
    Task<Visit?> GetByIdAsync(int Id);
    Task UpdateAsync(Visit visit);
    Task DeleteAsync(int Id);
}