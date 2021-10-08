using ApiVersioning.Domain.Forecast;
using Microsoft.Extensions.DependencyInjection;

namespace ApiVersioning.Infrastructure.ServiceCollectionExtensions
{
    public static class DomainServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddTransient<Forecaster>();
            
            return services;
        }
    }
}