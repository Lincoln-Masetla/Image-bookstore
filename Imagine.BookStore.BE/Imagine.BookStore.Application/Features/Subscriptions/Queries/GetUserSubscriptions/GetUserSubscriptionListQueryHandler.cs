using AutoMapper;
using Imagine.BookStore.Application.Contracts.Persistence;
using Imagine.BookStore.Domain.Entities;
using MediatR;

namespace Imagine.BookStore.Application.Features.Subscriptions.Queries.GetUserSubscriptions;
public class GetUserSubscriptionListQueryHandler : IRequestHandler<GetUserSubscriptionListQuery, List<UserSubscriptionVm>>
{
    private readonly IGenericRepositoryAsync<Subscription> _subscriptionRepository;
    private readonly IMapper _mapper;

    public GetUserSubscriptionListQueryHandler(IMapper mapper, IGenericRepositoryAsync<Subscription> subscriptionRepository)
    {
        _mapper = mapper;
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<List<UserSubscriptionVm>> Handle(GetUserSubscriptionListQuery request, CancellationToken cancellationToken)
    {
        var allSubscriptions = await _subscriptionRepository.ListAllAsync();
        var userSubscriptions = allSubscriptions.Where(x => x.UserId == request.UserId).Select( userSubscription => new UserSubscriptionVm { BookId = userSubscription.BookId,
                                UserId = userSubscription.UserId,
                                Id = userSubscription.Id});
        return _mapper.Map<List<UserSubscriptionVm>>(userSubscriptions);
    }
}
