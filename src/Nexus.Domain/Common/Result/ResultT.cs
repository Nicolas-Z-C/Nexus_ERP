using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexus.Domain.Errors;

namespace Nexus.Domain.Common.Result
{
    public sealed class Result<T> : Result
{
    private readonly T? _value;

    private Result(T value) : base(true, Error.None) => _value = value;

    private Result(Error error) : base(false, error) => _value = default;
    private Result(IEnumerable<Error> errors) : base(false, errors) => _value = default;

    public T Value => IsSuccess ? _value! : throw new InvalidOperationException("Resultado fallido no tiene valor.");

    public static Result<T> Success(T value) => new(value);
    public new static Result<T> Failure(Error error) => new(error);
    public new static Result<T> Failure(IEnumerable<Error> errors) => new(errors);

    public static implicit operator Result<T>(T value) => Success(value);
    public static implicit operator Result<T>(Error error) => Failure(error);
}
}
