using Microsoft.AspNetCore.Mvc;
using web.api.books.BusinessLogic;
using web.api.books.BusinessLogic.RequestModels;
using web.api.books.Contracts;

namespace web.api.books.Controllers;

[ApiController]
[Route("api/v1")]
public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;

    private readonly IBookService _bookService;

    public BooksController(
        ILogger<BooksController> logger,
        IBookService bookService)
    {
        _logger = logger;
        _bookService = bookService;
    }

    [HttpGet("getAllBooks")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _bookService.GetAllBooksAsync());
    }

    [HttpPost("createBook")]
    public async Task<IActionResult> CreateAsync(BookRequest bookRequest)
    {
        await _bookService.CreateAsync(bookRequest);
        return NoContent();
    }
}
