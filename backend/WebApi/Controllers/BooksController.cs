using Microsoft.AspNetCore.Mvc;
using WebApi.Services.Dtos;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers;

[Route("books")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookDto>>> GetBooksAsync()
    {
        return await _bookService.GetBooksAsync();
    }
}
