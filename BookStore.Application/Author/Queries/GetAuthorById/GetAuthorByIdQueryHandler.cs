using AutoMapper;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Author.Queries.GetAuthorById;

public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Domain.Entities.Author>
{
    private readonly IMapper _mapper;
    private readonly IAuthorRepository _authorRepository;

    public GetAuthorByIdQueryHandler(IMapper mapper, IAuthorRepository authorRepository)
    {
        _mapper = mapper;
        _authorRepository = authorRepository;
    }

    public async Task<Domain.Entities.Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetById(request.Id);
        var dto = _mapper.Map<Domain.Entities.Author>(author);
        return dto;
    }
}
