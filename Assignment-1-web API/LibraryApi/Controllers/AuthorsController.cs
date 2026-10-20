using LibraryApi.Data;
using LibraryApi.Dtos;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly LibraryDbContext _context;

    public AuthorsController(LibraryDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
    {
        return await _context.Authors
            .Select(author => new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                BirthDate = author.BirthDate
            })
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
    {
        var author = await _context.Authors.FindAsync(id);

        if (author == null)
        {
            return NotFound();
        }

        return new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            BirthDate = author.BirthDate
        };
    }

    [HttpPost]
    public async Task<ActionResult<AuthorDto>> CreateAuthor(AuthorDto dto)
    {
        var author = new Author
        {
            Name = dto.Name,
            BirthDate = dto.BirthDate
        };

        _context.Authors.Add(author);
        await _context.SaveChangesAsync();

        dto.Id = author.Id;
        return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthor(int id, AuthorDto dto)
    {
        if (id != dto.Id)
        {
            return BadRequest();
        }

        var author = await _context.Authors.FindAsync(id);

        if (author == null)
        {
            return NotFound();
        }

        author.Name = dto.Name;
        author.BirthDate = dto.BirthDate;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        var author = await _context.Authors.FindAsync(id);

        if (author == null)
        {
            return NotFound();
        }

        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
