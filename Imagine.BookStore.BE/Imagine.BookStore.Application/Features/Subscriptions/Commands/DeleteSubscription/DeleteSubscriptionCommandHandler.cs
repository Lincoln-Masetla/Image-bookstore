using AutoMapper;
using Imagine.BookStore.Application.Contracts.Persistence;
using Imagine.BookStore.Application.Features.Subscriptions.Commands.CreateSubscription;
using Imagine.BookStore.Domain.Entities;
using MediatR;

namespace Imagine.BookStore.Application.Features.Subscriptions.Commands.DeleteSubscription
{
    public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand, DeleteSubscriptionCommandResponse>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;

        public DeleteSubscriptionCommandHandler(IMapper mapper,
            ISubscriptionRepository subscriptionRepository)
        {
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<DeleteSubscriptionCommandResponse> Handle(DeleteSubscriptionCommand request,
            CancellationToken cancellationToken)
        {
            var deleteSubscriptionCommandResponse = new DeleteSubscriptionCommandResponse();

            var subscription = await _subscriptionRepository.GetSubscriptionsByUserIdAndBookId(request.UserId, request.BookId);
            if(subscription != null)
            {
                await _subscriptionRepository.DeleteAsync(subscription);
            }

            return deleteSubscriptionCommandResponse;
        }
    }
}
