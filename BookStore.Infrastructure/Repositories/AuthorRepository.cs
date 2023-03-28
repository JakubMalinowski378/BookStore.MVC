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

    public async Task Create(Author author)
    {
        _dbContext.Add(author);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Author>> GetAll()
        => await _dbContext.Authors.ToListAsync();

    public async Task<Author?> GetById(int id)
        => await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
}
