using Imagine.BookStore.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Imagine.BookStore.Persistence.Context;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext()
    {

    }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
            .UseSqlServer("DataSource=app.db");
        }

    }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.Entity<Book>().HasData(
			new Book
			{
				Id = Guid.NewGuid(),
				Name = "Intimacies",
				PurchasePrice = 10M

			},
			new Book
			{
				Id = Guid.NewGuid(),
				Name = "The Love Songs of W.E.B. Du Bois",
				PurchasePrice = 20M

			},
			new Book
			{
				Id = Guid.NewGuid(),
				Name = "No One Is Talking About This",
				PurchasePrice = 30M

			},
			new Book
			{
				Id = Guid.NewGuid(),
				Name = "When We Cease to Understand the World",
				PurchasePrice = 40M

			},
			new Book
			{
				Id = Guid.NewGuid(),
				Name = "The Copenhagen Trilogy: Childhood; Youth; Dependency",
				PurchasePrice = 50M

			},
			new Book
			{
				Id = Guid.NewGuid(),
				Name = "How the Word Is Passed: A Reckoning With the History of Slavery Across America",
				PurchasePrice = 60M

			});
	}
}