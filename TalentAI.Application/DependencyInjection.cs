using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using FluentValidation;
using MediatR;
using TalentAI.Application.Behaviors;

using Microsoft.Extensions.DependencyInjection;

namespace TalentAI.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
    this IServiceCollection services)
{
    services.AddAutoMapper(
    cfg => { },
    typeof(DependencyInjection));

    services.AddValidatorsFromAssembly(
    typeof(DependencyInjection).Assembly);

    services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssembly(
            Assembly.GetExecutingAssembly()));

    services.AddTransient(
        typeof(IPipelineBehavior<,>),
        typeof(ValidationBehavior<,>));

    services.AddTransient(
        typeof(IPipelineBehavior<,>),
        typeof(LoggingBehavior<,>));

    services.AddTransient(
        typeof(IPipelineBehavior<,>),
        typeof(PerformanceBehavior<,>));

    return services;
}
}
