namespace MechControl.Domain.Core.Primitives.Result;

public class Result
{
    public Error? Error { get; internal protected init;  }

    public bool IsSuccess => Error is null;

    public bool IsFailure => !IsSuccess;
    protected Result() { }

    public static Result Ok() => new();
    public static Result<T> Ok<T>(T value) => new(value);

    public static Result Fail(Error error) => new() { Error = error };
    public static Result<T> Fail<T>(Error error) => new(default) { Error = error };

    public static Result Combine(params Result[] results)
    {
        if(results.All(r => r.IsSuccess)) return Ok();

        var errors = results.Where(r => r.IsFailure).Select(r => r.Error!);
        return Fail(new Error("combined_errors", $"One or more errors occurred: {string.Join(", ", errors)}"));
    }

    #region Implicit Operators

    public static implicit operator Result(Error error) => Fail(error);

    public static implicit operator Error(Result result) => result.Error ?? throw new InvalidOperationException();

    public static implicit operator bool(Result result) => result.IsSuccess;

    #endregion
}

public class Result<T> : Result
{
    private readonly T? _value;

    public T Value =>
        IsSuccess && _value is not null
            ? _value
            : throw new InvalidOperationException("Result is not successful or value is null");

    internal protected Result(T? value) => _value = value;

    #region Implicit Operators

    public static implicit operator Result<T>(T value) => Ok(value);

    public static implicit operator T(Result<T> result) => result.Value;

    public static implicit operator Result<T>(Error error) => Fail<T>(error);

    public static implicit operator Error(Result<T> result) => result.Error is null ? throw new InvalidOperationException() : result.Error;

    public static implicit operator bool(Result<T> result) => result.IsSuccess;

    #endregion
}