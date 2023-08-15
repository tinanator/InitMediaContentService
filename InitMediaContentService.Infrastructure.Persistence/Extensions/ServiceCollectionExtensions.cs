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
            services.AddScoped<IRepository<Track, Guid>, Repository<Track, Guid>>();
            services.AddScoped<IRepository<Release, Guid>, Repository<Release, Guid>>();
            services.AddScoped<IRepository<Artist, Guid>, Repository<Artist, Guid>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
