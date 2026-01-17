using Microsoft.Extensions.DependencyInjection;
using SuiteRx.Interface.Application.Services;
using SuiteRx.Interface.Application.Services.Impl;

namespace SuiteRx.Interface.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRegistrationService, RegistrationService>();

            return services;
        }
    }
}
