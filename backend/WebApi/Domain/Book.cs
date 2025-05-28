namespace WebApi.Domain;

public class Book
{
    public int BookId { get; set; }

    public string Title { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int TotalCopies { get; set; } = 0;

    public int CopiesInUse { get; set; } = 0;

    public string? Type { get; set; }

    public string? ISBN { get; set; }

    public string? Category { get; set; }

    public Book(int bookId, string title, string firstName, string lastName, int totalCopies, int copiesInUse, 
        string? type, string? iSBN, string? category)
    {
        BookId = bookId;
        Title = title;
        FirstName = firstName;
        LastName = lastName;
        TotalCopies = totalCopies;
        CopiesInUse = copiesInUse;
        Type = type;
        ISBN = iSBN;
        Category = category;
    }
}

