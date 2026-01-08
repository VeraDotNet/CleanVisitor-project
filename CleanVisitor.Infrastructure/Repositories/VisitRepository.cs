using CleanVisitor.Core.Interfaces;
using CleanVisitor.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class VisitRepository : IVisitRepository
{
    private readonly ApplicationDbContext _context;

    public VisitRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Visit visit)
    {
        await _context.Visits.AddAsync(visit);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Visit>> GetAllAsync()
    {
        return await _context.Visits
            .Include(v => v.Visitor)
            .Include(v => v.Department)
            .ToListAsync();
    }
    public async Task<Visit?> GetByIdAsync(int id)
    {
        return await _context.Visits
            .Include(v => v.Visitor)
            .Include(v => v.Department)
            .FirstOrDefaultAsync(v => v.Id == id);
    }
    public async Task UpdateAsync(Visit visit)
    {
        _context.Visits.Update(visit);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var visit = await _context.Visits.FindAsync(id);
        if (visit != null)
        {
            _context.Visits.Remove(visit);
            await _context.SaveChangesAsync();
        }
    }
}