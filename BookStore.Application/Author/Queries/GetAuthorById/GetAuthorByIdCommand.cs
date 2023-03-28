using MediatR;

namespace BookStore.Application.Author.Queries.GetAuthorById;

public class GetAuthorByIdCommand : Domain.Entities.Author, IRequest<Domain.Entities.Author>
{
}
