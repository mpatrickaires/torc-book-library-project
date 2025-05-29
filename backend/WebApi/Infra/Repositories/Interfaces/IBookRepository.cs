using WebApi.Domain;
using WebApi.Services.Dtos;

namespace WebApi.Infra.Repositories.Interfaces;

public interface IBookRepository
{
    public Task<List<Book>> GetBooksAsync(BookFilterDto? filter = null);
    public Task<List<string>> GetBookTypesAsync();
    public Task<List<string>> GetBookCategoriesAsync();
}
