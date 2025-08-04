using cdbservice.Core.Domain;
using cdbservice.Core.UseCases;
using cdbservice.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace cdbservice.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IIndicadorFinanceiro, IndicadorFinanceiroCdiRepository>();
            services.AddScoped<ITaxaTbRepository, TaxaTbRepository>();
            services.AddScoped<ITaxaImpostoRendaPadraoRepository, TaxaImpostoRendaPadraoRepository>();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<CalcularCdbPosFixadoCommandHandler>();
            });

            return services;
        }
    }
}