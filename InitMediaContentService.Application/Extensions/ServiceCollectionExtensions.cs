using InitMediaContentService.Application.Mappers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InitMediaContentService.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<ArtistMapper>();
            services.AddScoped<TrackMapper>();
            services.AddScoped<ReleaseMapper>();

            return services;
        }
    }
}
