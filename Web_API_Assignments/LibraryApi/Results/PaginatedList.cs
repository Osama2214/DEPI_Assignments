namespace LibraryApi.Results;

public class PaginatedList<T>
{
    private int _pageSize = 10;

    public int PageNumber { get; set; } = 1;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = Math.Clamp(value, 1, 20);
    }

    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
    public IEnumerable<T> Data { get; set; } = new List<T>();
}
