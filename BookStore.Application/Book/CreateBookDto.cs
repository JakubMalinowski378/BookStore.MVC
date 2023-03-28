using BookStore.Domain.Entities;
using System.ComponentModel;

namespace BookStore.Application.Book;

public class CreateBookDto
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public Genre Genre { get; set; }
    public Language Language { get; set; }
    public int PageNumbers { get; set; }
    [DisplayName("Author")]
    public int AuthorId { get; set; }
}
