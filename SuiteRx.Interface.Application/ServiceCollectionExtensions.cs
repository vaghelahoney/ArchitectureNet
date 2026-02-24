using Microsoft.Extensions.DependencyInjection;
using SuiteRx.Interface.Application.Services;
using SuiteRx.Interface.Application.Services.Impl;
using FluentValidation;

namespace SuiteRx.Interface.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IClothesService, ClothesService>();

            // Register Validators
            services.AddValidatorsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
