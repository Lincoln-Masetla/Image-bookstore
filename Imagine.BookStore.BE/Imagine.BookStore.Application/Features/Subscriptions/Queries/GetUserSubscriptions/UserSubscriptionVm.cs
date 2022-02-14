namespace Imagine.BookStore.Application.Features.Subscriptions.Queries.GetUserSubscriptions
{
    public class UserSubscriptionVm
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
