using MediatR;

namespace BookStore.Application.Book.Queries.GetBooks;

public class GetBooksQuery : IRequest<IEnumerable<BookDto>>
{

}
