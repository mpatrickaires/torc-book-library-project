using Microsoft.EntityFrameworkCore;
using WebApi.Domain;
using WebApi.Infra.Db;
using WebApi.Infra.Repositories.Interfaces;

namespace WebApi.Infra.Repositories;

public class BookRepository : IBookRepository
{
    private readonly DbSet<Book> _books;

    public BookRepository(LibraryDbContext dbContext)
    {
        _books = dbContext.Books;
    }

    public Task<List<Book>> GetBooksAsync()
    {
        return _books.ToListAsync();
    }
}
