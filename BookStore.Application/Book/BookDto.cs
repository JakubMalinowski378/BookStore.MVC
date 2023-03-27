using BookStore.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.Book;

public class BookDto
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public Genre Genre { get; set; }
    public Language Language { get; set; }
    public int PageNumbers { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
    public DateTime PublishedDate { get; set; }
    public int AuthorId { get; set; }
    public Domain.Entities.Author Author { get; set; } = new();
}
