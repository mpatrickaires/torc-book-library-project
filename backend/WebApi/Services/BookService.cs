using WebApi.Infra.Repositories.Interfaces;
using WebApi.Services.Dtos;
using WebApi.Services.Interfaces;

namespace WebApi.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<BookDto>> GetBooksAsync(BookFilterDto? filter = null)
    {
        var books = await _bookRepository.GetBooksAsync(filter);
        return books.Select(book => new BookDto(book)).ToList();
    }

    public Task<List<string>> GetBookTypesAsync()
    {
        return _bookRepository.GetBookTypesAsync();
    }
}
