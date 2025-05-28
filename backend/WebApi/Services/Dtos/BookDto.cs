using WebApi.Domain;

namespace WebApi.Services.Dtos;

public class BookDto
{
    public string Title { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int TotalCopies { get; set; }

    public int CopiesInUse { get; set; }

    public string? Type { get; set; }

    public string? ISBN { get; set; }

    public string? Category { get; set; }

    public BookDto(Book book)
    {
        Title = book.Title;
        FirstName = book.FirstName;
        LastName = book.LastName;
        TotalCopies = book.TotalCopies;
        CopiesInUse = book.CopiesInUse;
        Type = book.Type;
        ISBN = book.ISBN;
        Category = book.Category;
    }
}
