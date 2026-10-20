namespace LibraryApi.Dtos;

public class AuthorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int AuthorId { get; set; }
}

public class BorrowerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime MembershipDate { get; set; }
}

public class LoanDto
{
    public int BookId { get; set; }
    public int BorrowerId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
