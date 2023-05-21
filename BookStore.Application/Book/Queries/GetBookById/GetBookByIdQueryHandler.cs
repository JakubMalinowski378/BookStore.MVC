using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Book.Queries.GetBookById;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Domain.Entities.Book>
{
    private readonly IBookRepository _bookRepository;

    public GetBookByIdQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Domain.Entities.Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetById(request.Id);
        return books;
    }
}
