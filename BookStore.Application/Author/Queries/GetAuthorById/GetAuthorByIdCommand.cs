using MediatR;

namespace BookStore.Application.Author.Queries.GetAuthorById;

public class GetAuthorByIdCommand : Domain.Entities.Authors, IRequest<Domain.Entities.Authors>
{
}
