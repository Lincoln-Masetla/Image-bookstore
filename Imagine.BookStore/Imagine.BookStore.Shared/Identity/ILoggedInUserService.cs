namespace Imagine.BookStore.Shared.Identity;
public interface ILoggedInUserService
{
    bool IsAuthenticated { get; }
    string UserId { get; }
}
