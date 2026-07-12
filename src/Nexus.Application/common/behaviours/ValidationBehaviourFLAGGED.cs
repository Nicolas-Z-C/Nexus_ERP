using FluentValidation;
using MediatR;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Errors;

namespace Nexus.Application.common.behaviours
{
    public class ValidationBehaviour<TRequest,TResponse> 
                 : IPipelineBehavior<TRequest, TResponse>
                 where TRequest: IRequest<TResponse>
                 where TResponse : Result
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            
            if(!_validators.Any())
                return await next();
            
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(_validators.Select( x => x.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                            .SelectMany( x => x.Errors)
                            .Where( f => f is not null)
                            .ToList();
            
            if(failures.Any())
            {
                var errors = failures
                             .GroupBy(f => f.PropertyName)
                             .Select(g => new Error(
                                 $"Validation.{g.Key}",
                                 string.Join(", ", g.Select(f => f.ErrorMessage))))
                             .ToList();

                return (TResponse)Result.Failure(errors);
            }

            return await next();
        } 
    }
}