using MediatR;

namespace Imagine.BookStore.Application.Features.Subscriptions.Commands.DeleteSubscription
{
    public class DeleteSubscriptionCommand : IRequest<DeleteSubscriptionCommandResponse>
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
    }
}
