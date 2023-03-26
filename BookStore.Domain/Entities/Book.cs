﻿using Microsoft.AspNetCore.Identity;

namespace BookStore.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public Genre Genre { get; set; }
    public Language Language { get; set; }
    public string Publisher { get; set; } = default!;
    public int PageNumbers { get; set; }
    public DateTime PublishedDate { get; set; } = DateTime.UtcNow;
    public Author Author { get; set; }
    public string? CreatedById { get; set; }
    public IdentityUser? CreatedBy { get; set; }

}
