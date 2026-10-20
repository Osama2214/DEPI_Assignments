namespace LibraryApi.Dtos.BorrowerDtos;

public class UpdateBorrowerRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime MembershipDate { get; set; }
}
