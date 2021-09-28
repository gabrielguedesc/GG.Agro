using GG.Agro.Application.Services;
using MediatR;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Injections
    {
        public static IServiceCollection InjectApplication(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("GG.Agro.Application");

            services.AddMediatR(assembly);
            services.AddAutoMapper(assembly);
            
            // Services
            services.AddScoped<IKeywordReplaceService, KeywordReplaceService>();

            return services;
        }
    }
}
