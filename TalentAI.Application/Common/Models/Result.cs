using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAI.Application.Common.Models;

public class Result
{
    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public string Message { get; }

    public string Error { get; }

    protected Result(bool isSuccess, string message, string error)
    {
        IsSuccess = isSuccess;
        Message = message;
        Error = error;
    }

    public static Result Success(string message = "Success")
    {
        return new Result(true, message, string.Empty);
    }

    public static Result Failure(string error)
    {
        return new Result(false, string.Empty, error);
    }

    public static Result NotFound(string message = "Resource not found.")
    {
        return new Result(false, string.Empty, message);
    }

    public static Result Validation(string message)
    {
        return new Result(false, string.Empty, message);
    }

    public static Result Unauthorized(string message = "Unauthorized.")
    {
        return new Result(false, string.Empty, message);
    }

    public static Result Forbidden(string message = "Forbidden.")
    {
        return new Result(false, string.Empty, message);
    }
}

public class Result<T> : Result
{
    public T? Value { get; }

    protected Result(T? value, bool isSuccess, string message, string error)
        : base(isSuccess, message, error)
    {
        Value = value;
    }

    public static Result<T> Success(T value, string message = "Success")
    {
        return new Result<T>(value, true, message, string.Empty);
    }

    public new static Result<T> Failure(string error)
    {
        return new Result<T>(default, false, string.Empty, error);
    }

    public new static Result<T> NotFound(string message = "Resource not found.")
    {
        return new Result<T>(default, false, string.Empty, message);
    }

    public new static Result<T> Validation(string message)
    {
        return new Result<T>(default, false, string.Empty, message);
    }

    public new static Result<T> Unauthorized(string message = "Unauthorized.")
    {
        return new Result<T>(default, false, string.Empty, message);
    }

    public new static Result<T> Forbidden(string message = "Forbidden.")
    {
        return new Result<T>(default, false, string.Empty, message);
    }
}
