using Imagine.BookStore.Shared.Identity;
using Microsoft.EntityFrameworkCore;

namespace Imagine.BookStore.Persistence.Context;

public class ApplicationDbContext : IdentityContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    //public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        foreach (var property in builder.Model.GetEntityTypes()
       .SelectMany(t => t.GetProperties())
       .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18,2)");
        }

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}