using Imagine.BookStore.Domain.Entities;

namespace Imagine.BookStore.Application.Contracts.Persistence
{
    public interface ISubscriptionRepository : IGenericRepositoryAsync<Subscription>
    {
        Task<Subscription> GetSubscriptionsByUserIdAndBookId(Guid UserId, Guid BookId);
    }
}
