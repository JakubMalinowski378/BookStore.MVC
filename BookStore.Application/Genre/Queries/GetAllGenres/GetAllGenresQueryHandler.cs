using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Genre.Queries.GetAllGenres;

public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, IEnumerable<Domain.Entities.Genre>>
{
    private readonly IGenreRepository _genreRepository;

    public GetAllGenresQueryHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Genre>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        var genres = await _genreRepository.GetAll();
        return genres;
    }
}
