using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;
using Nexus.Domain.Common.Result;

namespace Nexus.Application.common.behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
                                                      where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger) => _logger = logger;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName =   typeof(TRequest).Name;
            _logger.LogInformation($"Nexus → {requestName} Started", requestName);
            var time = Stopwatch.StartNew();

            var response = await next();
            
            time.Stop();
            
            if(response is Result result && result.IsFailure)
                _logger.LogInformation($"Nexus → {requestName} failed, Done in {time}ms",requestName, time.ElapsedMilliseconds);

            _logger.LogInformation($"Nexus → {requestName} Done in {time}ms",requestName, time.ElapsedMilliseconds);

            return response;
        }
    }
}