using MediatR;

namespace BookStore.Application.Genre.Queries.GetAllGenres;

public class GetAllGenresQuery : IRequest<IEnumerable<Domain.Entities.Genre>>
{

}
