using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuiteRx.Interface.Domain;
using SuiteRx.Interface.Persistance.Contexts;
using SuiteRx.Interface.Persistance.Repositories;

namespace SuiteRx.Interface.Persistance
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services,
 IConfigurationManager configuration)
        {
            services.AddScoped<PharmacyDBContext>();
            services.AddScoped<IRegistrationRepository, RegistrationRepository>();
            return services;
        }
    }
}
