using AutoMapper;
using LibraryApi.Data;
using LibraryApi.Dtos.AuthorDtos;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly LibraryDbContext _context;
    private readonly IMapper _mapper;

    public AuthorsController(LibraryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAuthors()
    {
        var authors = await _context.Authors
            .AsNoTracking()
            .ToListAsync();

        var response = _mapper.Map<List<Author>, List<GetAuthorResponse>>(authors);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthor(int id)
    {
        var author = await _context.Authors
            .AsNoTracking()
            .FirstOrDefaultAsync(author => author.Id == id);

        if (author == null)
        {
            return NotFound($"Author with Id = {id} is not found.");
        }

        var response = _mapper.Map<Author, GetAuthorResponse>(author);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthor(CreateAuthorRequest request)
    {
        var author = new Author
        {
            Name = request.Name,
            BirthDate = request.BirthDate
        };

        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();

        var response = _mapper.Map<Author, GetAuthorResponse>(author);
        return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthor(int id, UpdateAuthorRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        var author = await _context.Authors
            .FirstOrDefaultAsync(author => author.Id == id);

        if (author == null)
        {
            return NotFound($"Author with Id = {id} is not found.");
        }

        author.Name = request.Name;
        author.BirthDate = request.BirthDate;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        var author = await _context.Authors
            .FirstOrDefaultAsync(author => author.Id == id);

        if (author == null)
        {
            return NotFound($"Author with Id = {id} is not found.");
        }

        author.IsDeleted = true;
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
