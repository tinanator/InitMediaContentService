using InitMediaContentService.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InitMediaContentService.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediaContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MediaContext>(options => options.UseNpgsql(connectionString));

            return services;
        }
    }
}
