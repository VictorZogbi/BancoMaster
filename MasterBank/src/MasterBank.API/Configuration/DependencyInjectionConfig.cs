using MasterBank.Business.Interfaces;
using MasterBank.Business.Interfaces.Repository;
using MasterBank.Business.Interfaces.Service;
using MasterBank.Business.Notificacoes;
using MasterBank.Business.Services;
using MasterBank.Data.Context;
using MasterBank.Data.Repository;

namespace MasterBank.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MasterBankDbContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ITransferenciaService, TransferenciaService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
