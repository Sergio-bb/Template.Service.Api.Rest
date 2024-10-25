using None.Template.Service.Api.Rest.Domain.UseCase.Implementation;
using Template.Service.Api.Rest.Application.Host.Midellwares;
using Template.Service.Api.Rest.Domain.Model;
using Template.Service.Api.Rest.Domain.UseCase;
using Template.Service.Api.Rest.Domain.UseCase.Implementation;
using Template.Service.Api.Rest.Domain.UseCase.Ports;
using Template.Service.Api.Rest.DrivenAdapter.SqlServer;

namespace Template.Service.Api.Rest.Application.Host.Extensions;

public static class Services
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUseCase<Task<User>, User>, CreateUserUseCase>();
        services.AddScoped<IUseCase<Task<AccessToken>, ApiUser>, AuthenticateUseCase>();

        services.AddScoped<IUserRepository, UserAdapter>();


        services.AddTransient<GlobalExceptionHandler>();

        return services;
    }
}