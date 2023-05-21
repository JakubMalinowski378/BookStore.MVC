using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories;

public class LanguageRepository : ILanguageRepository
{
    private readonly BookStoreDbContext _dbContext;

    public LanguageRepository(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Language>> GetAll()
        => await _dbContext.Languages
        .ToListAsync();
}
