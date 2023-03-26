using AutoMapper;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Book.Queries.GetBooks;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookDto>>
{
    private readonly IBookRepository _bookStoreRepository;
    private readonly IMapper _mapper;

    public GetBooksQueryHandler(IBookRepository bookStoreRepository ,IMapper mapper)
    {
        _bookStoreRepository = bookStoreRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookStoreRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<BookDto>>(books);
        
        return dtos;
    }
}
