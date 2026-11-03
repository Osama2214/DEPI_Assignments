using System.ComponentModel.DataAnnotations;
using LibraryApi.Dtos.AuthorDtos;
using LibraryApi.Filters;
using LibraryApi.Results;
using LibraryApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
[ServiceFilter(typeof(ActionExecutionLoggingFilter))]
[ServiceFilter(typeof(ActionTimingFilter))]
[ServiceFilter(typeof(ExceptionHandlingFilter))]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _service;

    public AuthorsController(IAuthorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAuthors(
        [Range(1, int.MaxValue)] int pageNumber = 1,
        [Range(1, int.MaxValue)] int pageSize = 10,
        string? searchTerm = null)
    {
        var result = await _service.GetAllAsync(pageNumber, pageSize, searchTerm);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthor(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthor(CreateAuthorRequest request)
    {
        var result = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(GetAuthor), new { id = result.Value!.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthor(int id, UpdateAuthorRequest request)
    {
        if (id != request.Id)
            return BadRequest(Result.Failure("Route id must match the author id."));

        var result = await _service.UpdateAsync(request);
        return result.IsSuccess ? NoContent() : NotFound(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        var result = await _service.DeleteAsync(id);
        return result.IsSuccess ? NoContent() : NotFound(result);
    }
}
