using Imagine.BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Imagine.BookStore.Persistence.Context.Seeds.Identity
{
    public static class IdentityContextSeed
    {
        public static void IdentitySeed(this ModelBuilder modelBuilder)
        {
            CreateBasicUsers(modelBuilder);
        }

        private static void CreateBasicUsers(ModelBuilder modelBuilder)
        {
            List<ApplicationUser> users = DefaultUser.IdentityBasicUserList();
            modelBuilder.Entity<ApplicationUser>().HasData(users);
        }
    }
}
