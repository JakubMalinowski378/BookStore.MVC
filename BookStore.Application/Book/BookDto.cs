using BookStore.Domain.Entities;

namespace BookStore.Application.Book;

public class BookDto
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public Genre Genre { get; set; }
    public Language Language { get; set; }
    public string Publisher { get; set; } = default!;
    public int PageNumbers { get; set; }
    public DateTime PublishedDate { get; set; } = DateTime.UtcNow;
    public Author Author { get; set; }
}
