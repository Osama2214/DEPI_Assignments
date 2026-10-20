namespace LibraryApi.Models;

public class Borrower : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime MembershipDate { get; set; }

    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
