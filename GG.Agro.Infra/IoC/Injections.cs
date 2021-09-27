using GG.Agro.Infra.Abstractions;
using GG.Agro.Infra.Contexts;
using GG.Agro.Infra.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Injections
    {
        public static IServiceCollection InjectUow(this IServiceCollection services)
        {
            services.AddScoped<AgroContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection InjectEF(this IServiceCollection services, IConfiguration config)
        {
            var provider = config["Database:Provider"];

            switch (provider)
            {
                case "InMemory":
                    services.AddDbContext<AgroContext>(options =>
                        options.UseInMemoryDatabase("memDb")
                               .EnableDetailedErrors()
                               .LogTo(log => Debug.WriteLine(log)));
                break;
            }

            return services;
        }
    }
}
