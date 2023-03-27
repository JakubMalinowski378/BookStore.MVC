﻿using BookStore.Domain.Entities;
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

    public async Task Create(Book book)
    {
        _dbContext.Add(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Book>> GetAll()
        => await _dbContext.Books.Include("Author")
        .ToListAsync();
}
