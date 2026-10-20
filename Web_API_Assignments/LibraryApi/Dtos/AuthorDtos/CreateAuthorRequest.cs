namespace LibraryApi.Dtos.AuthorDtos;

public class CreateAuthorRequest
{
    public string Name { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}
