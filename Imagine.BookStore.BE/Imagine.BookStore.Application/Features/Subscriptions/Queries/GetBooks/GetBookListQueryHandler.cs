using AutoMapper;
using Imagine.BookStore.Application.Contracts.Persistence;
using Imagine.BookStore.Domain.Entities;
using MediatR;

namespace Imagine.BookStore.Application.Features.Subscriptions.Queries.GetBooks;

public class GetBookListQueryHandler : IRequestHandler<GetBookListQuery, List<GetBooksVm>>
{
    private readonly IGenericRepositoryAsync<Book> _bookRepository;
    private readonly IMapper _mapper;

    public GetBookListQueryHandler(IMapper mapper, IGenericRepositoryAsync<Book> bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }

    public async Task<List<GetBooksVm>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
    {
        var allBooks = await _bookRepository.ListAllAsync();
        return _mapper.Map<List<GetBooksVm>>(allBooks);
    }
}