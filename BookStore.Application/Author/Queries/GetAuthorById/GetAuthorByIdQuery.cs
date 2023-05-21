using MediatR;

namespace BookStore.Application.Author.Queries.GetAuthorById;

public class GetAuthorByIdQuery : Domain.Entities.Author, IRequest<Domain.Entities.Author>
{
}
