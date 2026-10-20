using AutoMapper;
using LibraryApi.Data;
using LibraryApi.Dtos.BorrowerDtos;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BorrowersController : ControllerBase
{
    private readonly LibraryDbContext _context;
    private readonly IMapper _mapper;

    public BorrowersController(LibraryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetBorrowers()
    {
        var borrowers = await _context.Borrowers
            .AsNoTracking()
            .ToListAsync();

        var response = _mapper.Map<List<Borrower>, List<GetBorrowerResponse>>(borrowers);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBorrower(int id)
    {
        var borrower = await _context.Borrowers
            .AsNoTracking()
            .FirstOrDefaultAsync(borrower => borrower.Id == id);

        if (borrower == null)
        {
            return NotFound($"Borrower with Id = {id} is not found.");
        }

        var response = _mapper.Map<Borrower, GetBorrowerResponse>(borrower);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBorrower(CreateBorrowerRequest request)
    {
        var borrower = new Borrower
        {
            Name = request.Name,
            MembershipDate = request.MembershipDate
        };

        await _context.Borrowers.AddAsync(borrower);
        await _context.SaveChangesAsync();

        var response = _mapper.Map<Borrower, GetBorrowerResponse>(borrower);
        return CreatedAtAction(nameof(GetBorrower), new { id = borrower.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBorrower(
        int id, UpdateBorrowerRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        var borrower = await _context.Borrowers
            .FirstOrDefaultAsync(borrower => borrower.Id == id);

        if (borrower == null)
        {
            return NotFound($"Borrower with Id = {id} is not found.");
        }

        borrower.Name = request.Name;
        borrower.MembershipDate = request.MembershipDate;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBorrower(int id)
    {
        var borrower = await _context.Borrowers
            .FirstOrDefaultAsync(borrower => borrower.Id == id);

        if (borrower == null)
        {
            return NotFound($"Borrower with Id = {id} is not found.");
        }

        borrower.IsDeleted = true;
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
