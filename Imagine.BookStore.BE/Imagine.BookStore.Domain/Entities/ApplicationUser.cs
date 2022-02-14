
using Microsoft.AspNetCore.Identity;

namespace Imagine.BookStore.Domain.Entities;
public class ApplicationUser : IdentityUser
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
}
