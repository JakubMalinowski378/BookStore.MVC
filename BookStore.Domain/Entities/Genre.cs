namespace BookStore.Domain.Entities;

public class Genre
{
    public int Id { get; set; }
    public string Value { get; set; } = default!;
    public List<Book> Books { get; set; } = new();
}
