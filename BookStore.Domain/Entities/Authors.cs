namespace BookStore.Domain.Entities;

public class Authors
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}
