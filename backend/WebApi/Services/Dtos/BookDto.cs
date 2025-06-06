﻿using WebApi.Domain;

namespace WebApi.Services.Dtos;

public class BookDto
{
    public string Title { get; set; }

    public string Author { get; set; }

    public int TotalCopies { get; set; }

    public string? Type { get; set; }

    public string? ISBN { get; set; }

    public string? Category { get; set; }

    public int AvailableCopies { get; set; }

    public BookDto(Book book)
    {
        Title = book.Title;
        Author = $"{book.FirstName} {book.LastName}";
        TotalCopies = book.TotalCopies;
        AvailableCopies = book.TotalCopies - book.CopiesInUse;
        Type = book.Type;
        ISBN = book.ISBN;
        Category = book.Category;
    }
}
