using MediatR;

namespace BookStore.Application.Author.Commands.EditAuthor;

public class EditAuthorCommand : AuthorDto, IRequest
{
    public int Id { get; set; }
}
