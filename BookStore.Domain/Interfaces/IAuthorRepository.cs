using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces;

public interface IAuthorRepository
{
    Task<IEnumerable<Authors>> GetAll();
    Task Create(Authors author);
    Task<Authors> GetById(int id);
    Task Commit();
    Task Delete(int id);
    Task<IEnumerable<Books>> GetAuthorBooks(int id);
}
