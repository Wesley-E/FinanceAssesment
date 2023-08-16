using AlmisAssessment.Configuration;
using AlmisAssessment.Repository;
using AlmisAssessment.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlmisAssessment
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSystemConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var appConfiguration = new AppConfiguration(configuration);
            services.AddSingleton<IAppConfiguration, AppConfiguration>(); 
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IRepository, Repository.Repository>();
        }
    }
}