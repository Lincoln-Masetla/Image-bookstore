using Imagine.BookStore.Application.Features.Subscriptions.Queries.GetBooks;
using Imagine.BookStore.Domain.Common;

namespace Imagine.BookStore.Application.Features.Subscriptions.Commands.CreateSubscription
{
    public class CreateSubscriptionCommandResponse : BaseResponse<string>
    {
        public CreateSubscriptionCommandResponse() : base()
        {
            
        }
        public CreateSubscriptionDto Subscription { get; set; }

    }
}
