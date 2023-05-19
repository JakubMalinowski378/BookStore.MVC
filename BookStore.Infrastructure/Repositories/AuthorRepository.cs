using BookStore.Application.Exceptions;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Persistance;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly BookStoreDbContext _dbContext;

    public AuthorRepository(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit()
        => await _dbContext.SaveChangesAsync();

    public async Task Create(Authors author)
    {
        _dbContext.Add(author);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var author = await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
        if (author == null)
        {
            throw new NotFoundException("Author not found");
        }
        _dbContext.Remove(author);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Authors>> GetAll()
        => await _dbContext.Authors
        .ToListAsync();

    public async Task<Authors> GetById(int id)
    {
        var author = await _dbContext.Authors
        .FirstOrDefaultAsync(x => x.Id == id);

        if (author is null)
            throw new NotFoundException("Author not found");

        return author;
    }

    public async Task<IEnumerable<Books>> GetAuthorBooks(int id)
    {
        var books = await _dbContext.Books
            .Include(x => x.Author)
            .Where(x => x.AuthorId == id).ToListAsync();
        return books;
    }
}
