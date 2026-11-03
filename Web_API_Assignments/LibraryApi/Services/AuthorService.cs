using AutoMapper;
using LibraryApi.Dtos.AuthorDtos;
using LibraryApi.Models;
using LibraryApi.Repositories;
using LibraryApi.Results;

namespace LibraryApi.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;

    public AuthorService(IAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GenericResult<PaginatedList<GetAuthorResponse>>> GetAllAsync(
        int pageNumber, int pageSize, string? searchTerm)
    {
        var authors = await _repository.GetAllAsync(pageNumber, pageSize, searchTerm);
        var response = new PaginatedList<GetAuthorResponse>
        {
            PageNumber = authors.PageNumber,
            PageSize = authors.PageSize,
            TotalRecords = authors.TotalRecords,
            TotalPages = authors.TotalPages,
            Data = _mapper.Map<IEnumerable<GetAuthorResponse>>(authors.Data)
        };
        return GenericResult<PaginatedList<GetAuthorResponse>>.Success(response);
    }

    public async Task<GenericResult<GetAuthorResponse>> GetByIdAsync(int id)
    {
        var author = await _repository.GetByIdAsync(id);
        if (author == null)
            return GenericResult<GetAuthorResponse>.Failure($"Author with Id = {id} is not found.");

        return GenericResult<GetAuthorResponse>.Success(_mapper.Map<GetAuthorResponse>(author));
    }

    public async Task<GenericResult<GetAuthorResponse>> CreateAsync(CreateAuthorRequest request)
    {
        var author = new Author
        {
            Name = request.Name,
            BirthDate = request.BirthDate
        };
        await _repository.CreateAsync(author);
        return GenericResult<GetAuthorResponse>.Success(_mapper.Map<GetAuthorResponse>(author));
    }

    public async Task<GenericResult<bool>> UpdateAsync(UpdateAuthorRequest request)
    {
        var author = await _repository.GetByIdAsync(request.Id);
        if (author == null)
            return GenericResult<bool>.Failure($"Author with Id = {request.Id} is not found.");

        author.Name = request.Name;
        author.BirthDate = request.BirthDate;
        var updated = await _repository.UpdateAsync(author);
        return updated ? GenericResult<bool>.Success(true)
            : GenericResult<bool>.Failure("Author could not be updated.");
    }

    public async Task<GenericResult<bool>> DeleteAsync(int id)
    {
        var deleted = await _repository.DeleteAsync(id);
        return deleted ? GenericResult<bool>.Success(true)
            : GenericResult<bool>.Failure($"Author with Id = {id} is not found.");
    }
}
