using FluentValidation;
using InitMediaContentService.Application.DTOs;
using InitMediaContentService.Application.Mappers;
using InitMediaContentService.Application.Validators;
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

            services.AddScoped<IValidator<ArtistDto>, ArtistValidator>();
            services.AddScoped<IValidator<TrackDto>, TrackValidator>();
            services.AddScoped<IValidator<ReleaseDto>, ReleaseValidator>();

            return services;
        }
    }
}
