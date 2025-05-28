using Microsoft.AspNetCore.Mvc;
using WebApi.Services.Dtos;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers;

[Route("books")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookDto>>> GetBooksAsync()
    {
        return await _bookService.GetBooksAsync();
    }
}
