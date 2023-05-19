using MediatR;

namespace BookStore.Application.Author.Commands.DeleteAuthor;

public class DeleteAuthorCommand : IRequest
{
    public int Id { get; set; }
}
