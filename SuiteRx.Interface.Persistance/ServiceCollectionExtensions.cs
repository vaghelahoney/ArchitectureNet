using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuiteRx.Interface.Domain;
using SuiteRx.Interface.Domain.Repositories;
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
            services.AddScoped<IClothesRepository, ClothesRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            return services;
        }
    }
}
