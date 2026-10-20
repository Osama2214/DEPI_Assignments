namespace LibraryApi.Dtos.BorrowerDtos;

public class GetBorrowerResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime MembershipDate { get; set; }
}
