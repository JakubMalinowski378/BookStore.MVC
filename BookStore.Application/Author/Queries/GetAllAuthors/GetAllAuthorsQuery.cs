using MediatR;

namespace BookStore.Application.Author.Queries.GetAuthors;

public class GetAllAuthorsQuery : IRequest<IEnumerable<Domain.Entities.Author>>
{

}
