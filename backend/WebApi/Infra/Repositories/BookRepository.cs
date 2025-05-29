using Microsoft.EntityFrameworkCore;
using WebApi.Domain;
using WebApi.Infra.Db;
using WebApi.Infra.Repositories.Interfaces;
using WebApi.Services.Dtos;

namespace WebApi.Infra.Repositories;

public class BookRepository : IBookRepository
{
    private readonly DbSet<Book> _books;

    public BookRepository(LibraryDbContext dbContext)
    {
        _books = dbContext.Books;
    }

    public Task<List<Book>> GetBooksAsync(BookFilterDto? filter = null)
    {
        var booksQuery = _books.AsQueryable();

        if (filter == null)
        {
            return _books.ToListAsync();
        }

        if (!string.IsNullOrWhiteSpace(filter.Title))
        {
            booksQuery = _books.Where(b => EF.Functions.ILike(b.Title, ToPatternMatching(filter.Title)));
        }
        if (!string.IsNullOrWhiteSpace(filter.Author))
        {
            booksQuery = _books.Where(b => 
                EF.Functions.ILike(b.FirstName, ToPatternMatching(filter.Author)) ||
                EF.Functions.ILike(b.LastName, ToPatternMatching(filter.Author)));
        }
        if (!string.IsNullOrWhiteSpace(filter.Type))
        {
            booksQuery = _books.Where(b => b.Type == filter.Type);
        }
        if (!string.IsNullOrWhiteSpace(filter.ISBN))
        {
            booksQuery = _books.Where(b => b.ISBN == filter.ISBN);
        }
        if (!string.IsNullOrWhiteSpace(filter.Category))
        {
            booksQuery = _books.Where(b => b.Category == filter.Category);
        }

        return booksQuery.ToListAsync();
    }

    public Task<List<string>> GetBookTypesAsync()
    {
        return _books.Where(b => b.Type != null).Select(b => b.Type).Distinct().OfType<string>().ToListAsync();
    }

    public Task<List<string>> GetBookCategoriesAsync()
    {
        return _books.Where(b => b.Category != null).Select(b => b.Category).Distinct().OfType<string>().ToListAsync();
    }

    private string ToPatternMatching(string text)
    {
        return $"%{text}%";
    }
}
