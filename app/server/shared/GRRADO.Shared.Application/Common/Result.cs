namespace GRRADO.Shared.Application.Common;

/// <summary>
/// Generic result wrapper for CQRS operations
/// </summary>
public class Result<T>
{
    public bool IsSuccess { get; private set; }
    public T? Value { get; private set; }
    public string? Error { get; private set; }

    public static Result<T> Success(T value) => new() { IsSuccess = true, Value = value };
    public static Result<T> Failure(string error) => new() { IsSuccess = false, Error = error };
}

/// <summary>
/// Non-generic result wrapper for operations without return value
/// </summary>
public class Result
{
    public bool IsSuccess { get; private set; }
    public string? Error { get; private set; }

    public static Result Success() => new() { IsSuccess = true };
    public static Result Failure(string error) => new() { IsSuccess = false, Error = error };
}
