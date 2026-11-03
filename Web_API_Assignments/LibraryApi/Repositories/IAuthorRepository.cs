using LibraryApi.Models;
using LibraryApi.Results;

namespace LibraryApi.Repositories;

public interface IAuthorRepository : IGenericRepository<Author>
{
    Task<PaginatedList<Author>> GetAllAsync(int pageNumber, int pageSize, string? searchTerm);
}
