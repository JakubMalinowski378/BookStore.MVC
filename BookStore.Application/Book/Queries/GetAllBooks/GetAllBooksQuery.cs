using MediatR;

namespace BookStore.Application.Book.Queries.GetBooks;

public class GetAllBooksQuery : IRequest<IEnumerable<BookDto>>
{

}
