using BookStore.Domain.Entities;
using MediatR;

namespace BookStore.Application.Book.Queries.GetBookById;

public class GetBookByIdQuery : IRequest<Books>
{
    public int Id { get; set; }
}
