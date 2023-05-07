using AutoMapper;
using BookStore.Application.ApplicationUser;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Book.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand>
{
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;

    public CreateBookCommandHandler(IMapper mapper, IBookRepository bookRepository, IAuthorRepository authorRepository, IUserContext userContext)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _userContext = userContext;
    }
    public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();
        if (currentUser == null)
        {
            return Unit.Value;
        }
        var book = _mapper.Map<Domain.Entities.Books>(request);

        var author = await _authorRepository.GetById(request.AuthorId);

        if (author == null)
        {
            return Unit.Value;
        }

        book.UserId = currentUser.Id;
        book.Author = author;

        await _bookRepository.Create(book);

        return Unit.Value;
    }
}
