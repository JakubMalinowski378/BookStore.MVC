using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAll();
    Task Create(Domain.Entities.Author author);
    Task<Author?> GetById(int id);
}
