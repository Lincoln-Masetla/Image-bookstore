using Imagine.BookStore.Domain.Entities;

namespace Imagine.BookStore.Persistence.Context.Seeds.Identity;
public static class DefaultUser
{
    public static List<ApplicationUser> IdentityBasicUserList()
    {
        return new List<ApplicationUser>()
        {
            new ApplicationUser
            {
                UserName = "superadmin",
                Email = "superadmin@gmail.com",
                FirstName = "Super",
                LastName = "User",
                // Password@123
                PasswordHash = "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==",
            }
        };
    }
}
