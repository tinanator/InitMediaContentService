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
            services.AddScoped<IRepository<Track, long>, Repository<Track, long>>();
            services.AddScoped<IRepository<Release, long>, Repository<Release, long>>();
            services.AddScoped<IRepository<Artist, long>, Repository<Artist, long>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
