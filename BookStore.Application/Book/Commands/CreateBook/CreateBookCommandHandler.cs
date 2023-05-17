using AutoMapper;
using BookStore.Application.ApplicationUser;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Book.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand>
{
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;
    private readonly IGenreRepository _genreRepository;
    private readonly IBookRepository _bookRepository;

    public CreateBookCommandHandler(IMapper mapper,
        IBookRepository bookRepository,
        IUserContext userContext,
        IGenreRepository genreRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _userContext = userContext;
        _genreRepository = genreRepository;
    }

    public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser() ?? throw new UnauthorizedAccessException();
        var book = _mapper.Map<Books>(request);
        var genres = await _genreRepository.GetAll();
        var genresList = genres.Where(x => request.GenresIds!.Contains(x.Id)).ToList();
        book.Genres = genresList;
        book.UserId = currentUser.Id;

        await _bookRepository.Create(book);

        return Unit.Value;
    }
}
