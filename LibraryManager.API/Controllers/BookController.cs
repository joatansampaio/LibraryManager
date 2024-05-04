using LibraryManager.Core.Entities;
using LibraryManager.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LibraryManager.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BookController(IBookService service) : ControllerBase
{
    private readonly IBookService _service = service;

    /// <summary>
    /// Get all books
    /// </summary>
    [SwaggerResponse(200, type: typeof(IEnumerable<Book>))]
    [HttpGet]
    public async Task<IActionResult> GetBooks() {
        var books = await _service.GetAll();
        return Ok(books);
    }

    /// <summary>
    /// Get a book by id
    /// </summary>
    /// <param name="id"></param>
    [SwaggerResponse(200, type: typeof(Book))]
    [SwaggerResponse(404)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id) {
        var book = await _service.GetById(id);

        if (book == null) {
            return NotFound();
        }

        return Ok(book);
    }

    /// <summary>
    /// Update a book
    /// </summary>
    /// <param name="id"></param>
    /// <param name="book"></param>
    [SwaggerResponse(204)]
    [SwaggerResponse(400)]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, Book book) {
        await _service.Update(id, book);
        return NoContent();
    }

    /// <summary>
    /// Add a book
    /// </summary>
    /// <param name="book"></param>
    [SwaggerResponse(201 , type: typeof(Book))]
    [HttpPost]
    public async Task<IActionResult> AddBook(Book book) {
        await _service.Add(book);
        return CreatedAtAction(nameof(AddBook), new { id = book.Id }, book);
    }

    /// <summary>
    /// Delete a book
    /// </summary>
    /// <param name="id"></param>
    [SwaggerResponse(204)]
    [SwaggerResponse(404)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id) {
        var book = await _service.GetById(id);  
        if (book == null) {
            return NotFound();
        }
        await _service.Delete(book.Id);
        return NoContent();
    }

}
