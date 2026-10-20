using AutoMapper;
using LibraryApi.Data;
using LibraryApi.Dtos.LoanDtos;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoansController : ControllerBase
{
    private readonly LibraryDbContext _context;
    private readonly IMapper _mapper;

    public LoansController(LibraryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetLoans()
    {
        var loans = await _context.Loans
            .Include(loan => loan.Book)
            .Include(loan => loan.Borrower)
            .AsNoTracking()
            .ToListAsync();

        var response = _mapper.Map<List<Loan>, List<GetLoanResponse>>(loans);
        return Ok(response);
    }

    [HttpGet("{bookId}/{borrowerId}")]
    public async Task<IActionResult> GetLoan(int bookId, int borrowerId)
    {
        var loan = await _context.Loans
            .Include(loan => loan.Book)
            .Include(loan => loan.Borrower)
            .AsNoTracking()
            .FirstOrDefaultAsync(loan =>
                loan.BookId == bookId && loan.BorrowerId == borrowerId);

        if (loan == null)
        {
            return NotFound("Loan is not found.");
        }

        var response = _mapper.Map<Loan, GetLoanResponse>(loan);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLoan(CreateLoanRequest request)
    {
        var loan = new Loan
        {
            BookId = request.BookId,
            BorrowerId = request.BorrowerId,
            LoanDate = request.LoanDate,
            ReturnDate = request.ReturnDate
        };

        await _context.Loans.AddAsync(loan);
        await _context.SaveChangesAsync();
        await _context.Entry(loan).Reference(item => item.Book).LoadAsync();
        await _context.Entry(loan).Reference(item => item.Borrower).LoadAsync();

        var response = _mapper.Map<Loan, GetLoanResponse>(loan);
        return CreatedAtAction(nameof(GetLoan), new
        {
            bookId = loan.BookId,
            borrowerId = loan.BorrowerId
        }, response);
    }

    [HttpPut("{bookId}/{borrowerId}")]
    public async Task<IActionResult> UpdateLoan(
        int bookId, int borrowerId, UpdateLoanRequest request)
    {
        if (bookId != request.BookId || borrowerId != request.BorrowerId)
        {
            return BadRequest();
        }

        var loan = await _context.Loans
            .FirstOrDefaultAsync(loan =>
                loan.BookId == bookId && loan.BorrowerId == borrowerId);

        if (loan == null)
        {
            return NotFound("Loan is not found.");
        }

        loan.LoanDate = request.LoanDate;
        loan.ReturnDate = request.ReturnDate;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{bookId}/{borrowerId}")]
    public async Task<IActionResult> DeleteLoan(int bookId, int borrowerId)
    {
        var loan = await _context.Loans
            .FirstOrDefaultAsync(loan =>
                loan.BookId == bookId && loan.BorrowerId == borrowerId);

        if (loan == null)
        {
            return NotFound("Loan is not found.");
        }

        loan.IsDeleted = true;
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
