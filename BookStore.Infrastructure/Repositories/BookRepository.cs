using BookStore.Application.Exceptions;
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

    public async Task<Books> GetById(int id)
    {
        var book = await _dbContext.Books
            .Include("Author")
            .Include("Genres")
            .Include("Language")
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);
        if(book == null)
        {
            throw new NotFoundException("Book not found");
        }
        return book;
    }
}
