namespace LibraryApi.Dtos.BorrowerDtos;

public class CreateBorrowerRequest
{
    public string Name { get; set; } = string.Empty;
    public DateTime MembershipDate { get; set; }
}
