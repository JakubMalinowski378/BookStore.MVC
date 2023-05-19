using BookStore.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.Book;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public List<Genres> Genres { get; set; } = new();
    public Domain.Entities.Languages Language { get; set; } = default!;
    public int PageNumbers { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
    public DateTime PublishedDate { get; set; }
    public int AuthorId { get; set; }
    public Authors Author { get; set; } = new();
    public decimal Price { get; set; }
}
