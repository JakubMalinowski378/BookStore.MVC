using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Author.Queries.GetAuthorBooks;

public class GetAuthorBooksQueryHandler : IRequestHandler<GetAuthorBooksQuery, IEnumerable<Domain.Entities.Book>>
{
    private readonly IAuthorRepository _authorRepository;

    public GetAuthorBooksQueryHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Book>> Handle(GetAuthorBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _authorRepository.GetAuthorBooks(request.Id);
        return books;
    }
}
