using BookStore.Domain.Entities;
using MediatR;

namespace BookStore.Application.Book.Queries.GetBookById;

public class GetBookByIdQuery : IRequest<Domain.Entities.Book>
{
    public int Id { get; set; }
}
