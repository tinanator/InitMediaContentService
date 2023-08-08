using InitMediaContentService.Domain.Interfaces;
using InitMediaContentService.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using InitMediaContentService.Infrastructure.Persistence.Database;

namespace InitMediaContentService.Infrastructure.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Track>, Repository<Track>>();
            services.AddScoped<IRepository<Release>, Repository<Release>>();
            services.AddScoped<IRepository<Artist>, Repository<Artist>>();
            services.AddScoped<UnitOfWork>();

            return services;
        }
    }
}
