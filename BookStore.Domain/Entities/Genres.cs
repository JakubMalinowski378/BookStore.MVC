namespace BookStore.Domain.Entities;

public class Genres
{
    public int Id { get; set; }
    public string Genre { get; set; } = default!;
    public List<Books> Books { get; set; } = new();
}
