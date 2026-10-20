using LibraryApi.Data;
using LibraryApi.Dtos;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BorrowersController : ControllerBase
{
    private readonly LibraryDbContext _context;

    public BorrowersController(LibraryDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BorrowerDto>>> GetBorrowers()
    {
        return await _context.Borrowers
            .Select(borrower => new BorrowerDto
            {
                Id = borrower.Id,
                Name = borrower.Name,
                MembershipDate = borrower.MembershipDate
            })
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BorrowerDto>> GetBorrower(int id)
    {
        var borrower = await _context.Borrowers.FindAsync(id);

        if (borrower == null)
        {
            return NotFound();
        }

        return new BorrowerDto
        {
            Id = borrower.Id,
            Name = borrower.Name,
            MembershipDate = borrower.MembershipDate
        };
    }

    [HttpPost]
    public async Task<ActionResult<BorrowerDto>> CreateBorrower(BorrowerDto dto)
    {
        var borrower = new Borrower
        {
            Name = dto.Name,
            MembershipDate = dto.MembershipDate
        };

        _context.Borrowers.Add(borrower);
        await _context.SaveChangesAsync();

        dto.Id = borrower.Id;
        return CreatedAtAction(nameof(GetBorrower), new { id = borrower.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBorrower(int id, BorrowerDto dto)
    {
        if (id != dto.Id)
        {
            return BadRequest();
        }

        var borrower = await _context.Borrowers.FindAsync(id);

        if (borrower == null)
        {
            return NotFound();
        }

        borrower.Name = dto.Name;
        borrower.MembershipDate = dto.MembershipDate;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBorrower(int id)
    {
        var borrower = await _context.Borrowers.FindAsync(id);

        if (borrower == null)
        {
            return NotFound();
        }

        _context.Borrowers.Remove(borrower);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
