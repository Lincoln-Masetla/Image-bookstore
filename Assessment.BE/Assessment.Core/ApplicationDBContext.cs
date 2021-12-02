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
	}
}
