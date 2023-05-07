using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookStoreDbContext _dbContext;

    public BookRepository(BookStoreDbContext dbContext)
	{
        _dbContext = dbContext;
    }

    public async Task Create(Books book)
    {
        _dbContext.Add(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Books>> GetAll()
        => await _dbContext.Books
        .Include("Author")
        .Include("Genres")
        .Include("Language")
        .ToListAsync();
}
