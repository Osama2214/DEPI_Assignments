using LibraryApi.Data;
using LibraryApi.Dtos;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoansController : ControllerBase
{
    private readonly LibraryDbContext _context;

    public LoansController(LibraryDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LoanDto>>> GetLoans()
    {
        return await _context.Loans
            .Select(loan => new LoanDto
            {
                BookId = loan.BookId,
                BorrowerId = loan.BorrowerId,
                LoanDate = loan.LoanDate,
                ReturnDate = loan.ReturnDate
            })
            .ToListAsync();
    }

    [HttpGet("{bookId}/{borrowerId}")]
    public async Task<ActionResult<LoanDto>> GetLoan(int bookId, int borrowerId)
    {
        var loan = await _context.Loans.FindAsync(bookId, borrowerId);

        if (loan == null)
        {
            return NotFound();
        }

        return new LoanDto
        {
            BookId = loan.BookId,
            BorrowerId = loan.BorrowerId,
            LoanDate = loan.LoanDate,
            ReturnDate = loan.ReturnDate
        };
    }

    [HttpPost]
    public async Task<ActionResult<LoanDto>> CreateLoan(LoanDto dto)
    {
        var loan = new Loan
        {
            BookId = dto.BookId,
            BorrowerId = dto.BorrowerId,
            LoanDate = dto.LoanDate,
            ReturnDate = dto.ReturnDate
        };

        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetLoan),
            new { bookId = dto.BookId, borrowerId = dto.BorrowerId }, dto);
    }

    [HttpPut("{bookId}/{borrowerId}")]
    public async Task<IActionResult> UpdateLoan(int bookId, int borrowerId, LoanDto dto)
    {
        if (bookId != dto.BookId || borrowerId != dto.BorrowerId)
        {
            return BadRequest();
        }

        var loan = await _context.Loans.FindAsync(bookId, borrowerId);

        if (loan == null)
        {
            return NotFound();
        }

        loan.LoanDate = dto.LoanDate;
        loan.ReturnDate = dto.ReturnDate;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{bookId}/{borrowerId}")]
    public async Task<IActionResult> DeleteLoan(int bookId, int borrowerId)
    {
        var loan = await _context.Loans.FindAsync(bookId, borrowerId);

        if (loan == null)
        {
            return NotFound();
        }

        _context.Loans.Remove(loan);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
