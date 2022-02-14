using MediatR;

namespace Imagine.BookStore.Application.Features.Subscriptions.Queries.GetUserSubscriptions
{
    public class GetUserSubscriptionListQuery : IRequest<List<UserSubscriptionVm>>
    {
        public Guid UserId { get; set; }
    }
}
