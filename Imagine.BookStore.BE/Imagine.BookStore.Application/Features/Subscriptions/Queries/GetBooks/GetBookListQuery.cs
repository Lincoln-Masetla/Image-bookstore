using MediatR;

namespace Imagine.BookStore.Application.Features.Subscriptions.Queries.GetBooks
{
    public class GetBookListQuery : IRequest<List<GetBooksVm>>
    {
    }
}
