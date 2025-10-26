// MyFinance.Infrastructure/InfrastructureServiceRegistration.cs

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using my_finance_domain.Interfaces.Repositories;
using my_finance_infra.Persistence;
using my_finance_infra.Repositories;

namespace my_finance_infra;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}