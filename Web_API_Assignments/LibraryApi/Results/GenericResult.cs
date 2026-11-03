namespace LibraryApi.Results;

public class GenericResult<T> : Result
{
    public T? Value { get; }

    public GenericResult(bool isSuccess, T? value, string error)
        : base(isSuccess, error)
    {
        Value = value;
    }

    public static GenericResult<T> Success(T value) => new(true, value, string.Empty);
    public new static GenericResult<T> Failure(string error) => new(false, default, error);
}
