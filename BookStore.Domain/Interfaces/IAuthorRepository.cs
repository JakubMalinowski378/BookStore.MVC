using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAll();
    Task Create(Author author);
    Task<Author> GetById(int id);
    Task Commit();
    Task Delete(int id);
    Task<IEnumerable<Book>> GetAuthorBooks(int id);
}
