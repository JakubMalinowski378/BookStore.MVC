using AutoMapper;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Author.Commands;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = _mapper.Map<Domain.Entities.Author>(request);
        await _authorRepository.Create(author);
        return Unit.Value;
    }
}
