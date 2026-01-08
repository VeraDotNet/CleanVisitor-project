using CleanVisitor.Core.Interfaces;
using CleanVisitor.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanVisitor.Infrastructure.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDbContext _context;

    public DepartmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Department department)
    {
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Department>> GetAllAsync()
    {
        return await _context.Departments
            .Include(d => d.Visits)
            .ToListAsync();
    }
    public async Task<Department?> GetByIdAsync(int id)
    {
        return await _context.Departments
            .Include(d => d.Visits)
            .FirstOrDefaultAsync(d => d.Id == id);
    }
    public async Task UpdateAsync(Department department)
    {
        _context.Departments.Update(department);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department != null)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }
    }
}