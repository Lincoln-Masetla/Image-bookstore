using Assessment.Core.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Core
{
	public class ApplicationDBContext : IdentityDbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{
		}
		public DbSet<Book> Books { get; set; }
		public DbSet<Subscription> Subscriptions { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<Book>().HasData(
				new Book{
					Id = 1,
					Title = "Intimacies",
					Description = "By Katie Kitamura"

				},
				new Book
				{
					Id = 2,
					Title = "The Love Songs of W.E.B. Du Bois",
					Description = "By Honorée Fanonne Jeffers"

				},
				new Book
				{
					Id = 3,
					Title = "No One Is Talking About This",
					Description = "By Patricia Lockwood"

				},
				new Book
				{
					Id = 4,
					Title = "When We Cease to Understand the World",
					Description = "By Benjamín Labatut. Translated by Adrian Nathan West."

				},
				new Book
				{
					Id = 5,
					Title = "The Copenhagen Trilogy: Childhood; Youth; Dependency",
					Description = "By Tove Ditlevsen. Translated by Tiina Nunnally and Michael Favala Goldman."

				},
				new Book
				{
					Id = 6,
					Title = "How the Word Is Passed: A Reckoning With the History of Slavery Across America",
					Description = "By Clint Smith"

				});
		}
	}
}
