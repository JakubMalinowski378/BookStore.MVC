using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly BookStoreDbContext _dbContext;

    public GenreRepository(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Genre>> GetAll()
        => await _dbContext.Genres
        .ToListAsync();
}
