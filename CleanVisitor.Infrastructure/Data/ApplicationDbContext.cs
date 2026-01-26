using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.Identity.Client;

namespace CleanVisitor.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options){ }
    //public DbSet<Visitor> Visitors => Set<Visitor>();
    public DbSet<Visitor> Visitors {get; set;} = null!;
    public DbSet<Visit> Visits {get; set;} = null!;
    public DbSet<Department> Departments {get; set;} = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //link between visit and visitor
        builder.Entity<Visit>()
            .HasOne(v => v.Visitor)
            .WithMany(vr => vr.Visits)
            .HasForeignKey(v => v.IdVisitor)
            .OnDelete(DeleteBehavior.Restrict);

        //link between visit and department
        builder.Entity<Visit>()
            .HasOne(v => v.Department)
            .WithMany(d => d.Visits)
            .HasForeignKey(v => v.IdDepartment)
            .OnDelete(DeleteBehavior.Restrict); //Delete a Department does not delete the historical
    }
}