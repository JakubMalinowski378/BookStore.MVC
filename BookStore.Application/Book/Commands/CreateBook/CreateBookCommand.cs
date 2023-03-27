using MediatR;

namespace BookStore.Application.Book.Commands.CreateBook;

public class CreateBookCommand : CreateBookDto, IRequest
{

}
