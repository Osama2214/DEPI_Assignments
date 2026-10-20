using LibraryApi.Data;
using LibraryApi.Dtos;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly LibraryDbContext _context;

    public BooksController(LibraryDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
    {
        return await _context.Books
            .Select(book => new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                AuthorId = book.AuthorId
            })
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetBook(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            ISBN = book.ISBN,
            AuthorId = book.AuthorId
        };
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> CreateBook(BookDto dto)
    {
        var book = new Book
        {
            Title = dto.Title,
            ISBN = dto.ISBN,
            AuthorId = dto.AuthorId
        };

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        dto.Id = book.Id;
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, BookDto dto)
    {
        if (id != dto.Id)
        {
            return BadRequest();
        }

        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        book.Title = dto.Title;
        book.ISBN = dto.ISBN;
        book.AuthorId = dto.AuthorId;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
