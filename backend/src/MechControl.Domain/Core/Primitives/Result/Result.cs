namespace MechControl.Domain.Core.Primitives.Result;

public class Result
{
    public Error? Error { get; protected init;  }

    public bool IsSuccess => Error is null;

    public bool IsFailure => !IsSuccess;
    protected Result() { }

    public static Result Ok() => new Result();

    public static Result Fail(Error error) => new Result { Error = error };
    
    
    #region Implicit Operators

    public static implicit operator Result(Error error) => Fail(error);

    public static implicit operator Error(Result result) => result.Error ?? throw new InvalidOperationException();

    public static implicit operator bool(Result result) => result.IsSuccess;

    #endregion
}

public class Result<T> : Result
{
    public T Value { get; }

    protected Result(T value) =>
        Value = value;

    public static Result<T> Ok(T value) => new Result<T>(value);

    public new static Result<T> Fail(Error error) => new Result<T>(default!) { Error = error };
    

    #region Implicit Operators

    public static implicit operator Result<T>(T value) => Ok(value);

    public static implicit operator T(Result<T> result) => result.Value;

    public static implicit operator Result<T>(Error error) => Fail(error);

    public static implicit operator Error(Result<T> result) => result.Error is null ? throw new InvalidOperationException() : result.Error;

    public static implicit operator bool(Result<T> result) => result.IsSuccess;

    #endregion
}