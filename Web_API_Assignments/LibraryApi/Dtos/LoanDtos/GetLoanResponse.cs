namespace LibraryApi.Dtos.LoanDtos;

public class GetLoanResponse
{
    public int BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public int BorrowerId { get; set; }
    public string BorrowerName { get; set; } = string.Empty;
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
