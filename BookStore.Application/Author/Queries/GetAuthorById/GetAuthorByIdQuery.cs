using MediatR;

namespace BookStore.Application.Author.Queries.GetAuthorById;

public class GetAuthorByIdQuery : Domain.Entities.Authors, IRequest<Domain.Entities.Authors>
{
}
