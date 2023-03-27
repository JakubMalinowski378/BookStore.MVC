using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAll();
    Task Create(Book book);
}
