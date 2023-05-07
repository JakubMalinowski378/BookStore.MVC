using AutoMapper;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Author.Queries.GetAuthorById;

public class GetAuthorByIdCommandHandler : IRequestHandler<GetAuthorByIdCommand, Domain.Entities.Authors>
{
    private readonly IMapper _mapper;
    private readonly IAuthorRepository _authorRepository;

    public GetAuthorByIdCommandHandler(IMapper mapper, IAuthorRepository authorRepository)
    {
        _mapper = mapper;
        _authorRepository = authorRepository;
    }

    public async Task<Domain.Entities.Authors> Handle(GetAuthorByIdCommand request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetById(request.Id);
        var dto = _mapper.Map<Domain.Entities.Authors>(author);
        return dto;
    }
}
