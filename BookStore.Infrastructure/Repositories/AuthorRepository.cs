using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Persistance;
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

    public async Task<IEnumerable<Authors>> GetAll()
        => await _dbContext.Authors
        .AsNoTracking()
        .ToListAsync();

    public async Task<Authors?> GetById(int id)
        => await _dbContext.Authors
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Id == id);
}
