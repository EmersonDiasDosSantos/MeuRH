using Domain.Commands;
using Domain;
using FluentValidation.AspNetCore;
using MediatR;
using FluentValidation;

namespace Services.Extension;

public static class MediatorExtension
{
    public static IServiceCollection AddMediatorWithValidation(this IServiceCollection services)
    {
        services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());
        
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly);
        });

        services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
