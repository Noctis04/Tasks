using Microsoft.EntityFrameworkCore;
using NorbitTask_2.UserClasses;

namespace NorbitTask_2
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddManagers();
            services.AddDatabase(configuration);
            return services;
        }
        private static IServiceCollection AddManagers(this IServiceCollection services)
        {
            services.AddScoped<IOwnerInterface, OwnerManager>();
            return services;
        }
        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OwnerContext>(builder =>
                builder.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
