using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexus.Domain.Errors;

namespace Nexus.Domain.Common.Result
{
    public class Result
    {

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public IEnumerable<Error> Errors { get; }
        public Error Error {get;}
        protected Result(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }
        protected Result(bool isSuccess, IEnumerable<Error> errors)
        {
            IsSuccess = isSuccess;
            Errors = errors ?? Enumerable.Empty<Error>();
        }

        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new(false, error);
        public static Result Failure(IEnumerable<Error> errors) => new(false, errors);
        public static implicit operator Result(Error error) => Failure(error);
    }
}