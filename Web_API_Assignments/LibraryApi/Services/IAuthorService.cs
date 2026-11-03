using LibraryApi.Dtos.AuthorDtos;
using LibraryApi.Results;

namespace LibraryApi.Services;

public interface IAuthorService
{
    Task<GenericResult<PaginatedList<GetAuthorResponse>>> GetAllAsync(
        int pageNumber, int pageSize, string? searchTerm);
    Task<GenericResult<GetAuthorResponse>> GetByIdAsync(int id);
    Task<GenericResult<GetAuthorResponse>> CreateAsync(CreateAuthorRequest request);
    Task<GenericResult<bool>> UpdateAsync(UpdateAuthorRequest request);
    Task<GenericResult<bool>> DeleteAsync(int id);
}
