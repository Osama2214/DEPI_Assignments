using AutoMapper;
using LibraryApi.Data;
using LibraryApi.Dtos.BookDtos;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly LibraryDbContext _context;
    private readonly IMapper _mapper;

    public BooksController(LibraryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _context.Books
            .Include(book => book.Author)
            .AsNoTracking()
            .ToListAsync();

        var response = _mapper.Map<List<Book>, List<GetBookResponse>>(books);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var book = await _context.Books
            .Include(book => book.Author)
            .AsNoTracking()
            .FirstOrDefaultAsync(book => book.Id == id);

        if (book == null)
        {
            return NotFound($"Book with Id = {id} is not found.");
        }

        var response = _mapper.Map<Book, GetBookResponse>(book);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(CreateBookRequest request)
    {
        var book = new Book
        {
            Title = request.Title,
            ISBN = request.ISBN,
            AuthorId = request.AuthorId
        };

        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        await _context.Entry(book).Reference(item => item.Author).LoadAsync();

        var response = _mapper.Map<Book, GetBookResponse>(book);
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, UpdateBookRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        var book = await _context.Books
            .FirstOrDefaultAsync(book => book.Id == id);

        if (book == null)
        {
            return NotFound($"Book with Id = {id} is not found.");
        }

        book.Title = request.Title;
        book.ISBN = request.ISBN;
        book.AuthorId = request.AuthorId;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.Books
            .FirstOrDefaultAsync(book => book.Id == id);

        if (book == null)
        {
            return NotFound($"Book with Id = {id} is not found.");
        }

        book.IsDeleted = true;
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
