using InitMediaContentService.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InitMediaContentService.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static async Task<IServiceCollection> AddMediaContext(this IServiceCollection services, ISecretStorage storage, string secretName)
        {
            var connectionString = await storage.GetSecret(secretName);
            services.AddDbContext<MediaContext>(options => options.UseNpgsql(connectionString));

            return services;
        }
    }
}
