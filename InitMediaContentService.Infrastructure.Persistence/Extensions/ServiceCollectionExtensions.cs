﻿using InitMediaContentService.Database;
using InitMediaContentService.Domain.Interfaces;
using InitMediaContentService.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace InitMediaContentService.Infrastructure.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Track>, Repository<Track>>();
            services.AddScoped<IRepository<Release>, Repository<Release>>();
            services.AddScoped<IRepository<Artist>, Repository<Artist>>();

            return services;
        }
    }
}