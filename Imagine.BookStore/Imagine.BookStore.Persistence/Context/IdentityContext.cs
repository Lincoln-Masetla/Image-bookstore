using Imagine.BookStore.Domain.Entities;
using Imagine.BookStore.Persistence.Context.Seeds.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Imagine.BookStore.Persistence.Context;

public class IdentityContext : IdentityDbContext<ApplicationUser>
{
    public IdentityContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Custom Identity table names
        builder.Entity<ApplicationUser>(entity =>
        {
            entity.ToTable("User", "Identity");
        });
        #endregion

        builder.IdentitySeed();
    }
}
