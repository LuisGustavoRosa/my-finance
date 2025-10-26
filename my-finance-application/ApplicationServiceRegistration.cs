using Microsoft.Extensions.DependencyInjection;
using my_finance_application.Services;
using my_finance_domain.Interfaces.Services;

namespace my_finance_application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}