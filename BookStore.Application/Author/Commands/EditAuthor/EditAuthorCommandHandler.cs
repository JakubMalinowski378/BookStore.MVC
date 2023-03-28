using AutoMapper;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Author.Commands.EditAuthor;

public class EditAuthorCommandHandler : IRequestHandler<EditAuthorCommand>
{
    private readonly IMapper _mapper;
    private readonly IAuthorRepository _authorRepository;

    public EditAuthorCommandHandler(IMapper mapper, IAuthorRepository authorRepository)
    {
        _mapper = mapper;
        _authorRepository = authorRepository;
    }

    public async Task<Unit> Handle(EditAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetById(request.Id);
        if (author == null)
        {
            return Unit.Value;
        }

        author.FirstName = request.FirstName;
        author.LastName = request.LastName;

        await _authorRepository.Commit();
        return Unit.Value;
    }
}
