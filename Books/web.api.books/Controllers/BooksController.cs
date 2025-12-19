using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;
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

    [HttpGet("getBook/{id:int}")]
    public async Task<IActionResult> GetBookAsync(int id)
    {
        try
        {
            var book = await _bookService.GetBookAsync(id);
            return Ok(book);
        }
        catch(NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("createBook")]
    public async Task<IActionResult> CreateAsync(BookRequest bookRequest)
    {
        await _bookService.CreateAsync(bookRequest);
        return NoContent();
    }

    [HttpDelete("deleteBook/{id:int}")]
    public async Task<IActionResult> DeleteBookByIdAsync(int id)
    {
        try
        {
            var deletedBookId = await _bookService.DeleteBookByIdAsync(id);
            return Ok(deletedBookId);
        }
        catch(NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("updateBook/{id:int}")]
    public async Task<IActionResult> UpdateBookAsync(int id, BookUpdateRequest bookRequest)
    {
        try
        {
            var updatedBook = await _bookService.UpdateBookAsync(id, bookRequest);
            return Ok(updatedBook);
        }
        catch(NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
