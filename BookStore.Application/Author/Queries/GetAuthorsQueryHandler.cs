using AutoMapper;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Author.Queries;

public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, IEnumerable<Domain.Entities.Author>>
{
    private readonly IAuthorRepository _authorRepository;

    public GetAuthorsQueryHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Author>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _authorRepository.GetAll();
        
        return authors;
    }
}
