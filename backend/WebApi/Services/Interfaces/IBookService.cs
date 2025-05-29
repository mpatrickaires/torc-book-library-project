using WebApi.Services.Dtos;

namespace WebApi.Services.Interfaces;

public interface IBookService
{
    public Task<List<BookDto>> GetBooksAsync(BookFilterDto? filter = null);
    public Task<List<string>> GetBookTypesAsync();
}
