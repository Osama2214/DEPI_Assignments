using LibraryApi.Data;
using LibraryApi.Models;
using LibraryApi.Results;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Repositories;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(LibraryDbContext context) : base(context)
    {
    }

    public async Task<PaginatedList<Author>> GetAllAsync(
        int pageNumber, int pageSize, string? searchTerm)
    {
        var query = _context.Authors.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(searchTerm))
            query = query.Where(author => author.Name.Contains(searchTerm));

        var page = new PaginatedList<Author>
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalRecords = await query.CountAsync()
        };
        page.TotalPages = (int)Math.Ceiling(page.TotalRecords / (double)page.PageSize);

        if (pageNumber > page.TotalPages)
            return page;

        page.Data = await query.OrderBy(author => author.Id)
            .Skip((pageNumber - 1) * page.PageSize)
            .Take(page.PageSize)
            .ToListAsync();

        return page;
    }
}
