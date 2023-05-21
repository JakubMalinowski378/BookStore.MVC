using System.ComponentModel;

namespace BookStore.Application.Book;

public class CreateBookDto
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public List<Domain.Entities.Genre> Genres { get; set; } = new();
    public int[]? GenresIds { get; set; }
    public int LanguageId { get; set; } = new();
    public int PageNumbers { get; set; }
    [DisplayName("Author")]
    public int AuthorId { get; set; }
    public decimal Price { get; set; }
}
