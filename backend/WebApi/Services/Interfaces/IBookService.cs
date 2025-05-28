using WebApi.Services.Dtos;

namespace WebApi.Services.Interfaces;

public interface IBookService
{
    public Task<List<BookDto>> GetBooksAsync();
}
