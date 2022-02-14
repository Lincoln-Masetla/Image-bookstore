using Microsoft.AspNetCore.Identity;

namespace Imagine.BookStore.Application.Contracts.Persistence
{
    public interface IIdentityService
    {
        Task<Object> Login(string Username, string password);
        Task<IdentityResult> Register(string Username, string password, string email);
    }
}
