using BookStore.Domain.Entities;
using MediatR;

namespace BookStore.Application.Author.Queries.GetAuthorBooks;

public class GetAuthorBooksQuery : IRequest<IEnumerable<Domain.Entities.Book>>
{
    public int Id { get; set; }
}
