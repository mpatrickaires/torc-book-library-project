using WebApi.Domain;

namespace WebApi.Infra.Repositories.Interfaces;

public interface IBookRepository
{
    public Task<List<Book>> GetBooksAsync();
}
