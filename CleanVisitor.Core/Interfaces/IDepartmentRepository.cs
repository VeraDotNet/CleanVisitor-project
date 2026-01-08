namespace CleanVisitor.Core.Interfaces;

public interface IDepartmentRepository
{
    Task AddAsync(Department department);
    Task<List<Department>> GetAllAsync();
    Task<Department?> GetByIdAsync(int Id);
    Task UpdateAsync(Department department);
    Task DeleteAsync(int Id);
}