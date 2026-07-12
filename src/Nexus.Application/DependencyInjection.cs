using System.Reflection;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Nexus.Application.common.behaviours;

namespace Nexus.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            //MediatR

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                // Pipeline
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(CachingBehaviour<,>));
            });

            // ─── FluentValidation ─────────────────────────────────────────
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // ─── Mapster ──────────────────────────────────────────────────
            services.AddMapster();

            return services;
        }
    }
}