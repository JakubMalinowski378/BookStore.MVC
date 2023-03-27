using MediatR;

namespace BookStore.Application.Author.Queries;

public class GetAuthorsQuery : IRequest<IEnumerable<Domain.Entities.Author>>
{

}
