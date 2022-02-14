using AutoMapper;
using Imagine.BookStore.Application.Features.Subscriptions.Commands.CreateSubscription;
using Imagine.BookStore.Application.Features.Subscriptions.Commands.DeleteSubscription;
using Imagine.BookStore.Application.Features.Subscriptions.Queries.GetBooks;
using Imagine.BookStore.Application.Features.Subscriptions.Queries.GetUserSubscriptions;
using Imagine.BookStore.Domain.Entities;

namespace Imagine.BookStore.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, GetBooksVm>();
            CreateMap<Subscription, UserSubscriptionVm>();
            CreateMap<Subscription, CreateSubscriptionCommand>().ReverseMap();
            CreateMap<Subscription, CreateSubscriptionDto>().ReverseMap();
             CreateMap<Subscription, DeleteSubscriptionCommand>().ReverseMap();
        }
    }
}
