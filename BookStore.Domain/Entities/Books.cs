using Microsoft.AspNetCore.Identity;

namespace BookStore.Domain.Entities;

public class Books
{
    public int Id { get; set; }
    public List<Genres> Genres { get; set; } = new();
    public Languages Language { get; set; } = default!;
    public Authors Author { get; set; } = default!;
    public IdentityUser User { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int PageNumbers { get; set; }
    public DateTime PublishedDate { get; set; } = DateTime.Now;
    public decimal Price { get; set; }
}
