namespace LibraryApi.Dtos.BookDtos;

public class CreateBookRequest
{
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int AuthorId { get; set; }
}
