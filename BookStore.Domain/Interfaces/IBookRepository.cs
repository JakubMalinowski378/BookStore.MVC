using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Books>> GetAll();
    Task Create(Books book);
    Task<Books> GetById(int id);
}
