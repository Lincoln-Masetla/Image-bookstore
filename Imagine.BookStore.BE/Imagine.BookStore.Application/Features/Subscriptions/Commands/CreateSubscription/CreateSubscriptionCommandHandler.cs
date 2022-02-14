using AutoMapper;
using Imagine.BookStore.Application.Contracts.Persistence;
using Imagine.BookStore.Application.Features.Subscriptions.Queries.GetBooks;
using Imagine.BookStore.Domain.Entities;
using MediatR;

namespace Imagine.BookStore.Application.Features.Subscriptions.Commands.CreateSubscription
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, CreateSubscriptionCommandResponse>
    {
        private readonly IGenericRepositoryAsync<Subscription> _subscriptionRepository;
        private readonly IMapper _mapper;

        public CreateSubscriptionCommandHandler(IMapper mapper,
            IGenericRepositoryAsync<Subscription> subscriptionRepository)
        {
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<CreateSubscriptionCommandResponse> Handle(CreateSubscriptionCommand request,
            CancellationToken cancellationToken)
        {
            var createSubscriptionCommandResponse = new CreateSubscriptionCommandResponse();
              
            var subscription = new Subscription() 
            { 
                BookId  = request.BookId, 
                UserId = request.UserId 
            };
            subscription = await _subscriptionRepository.AddAsync(subscription);
            createSubscriptionCommandResponse.Subscription = _mapper.Map<CreateSubscriptionDto>(subscription);

            return createSubscriptionCommandResponse;
        }
    }
}
