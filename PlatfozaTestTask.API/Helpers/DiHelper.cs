using Microsoft.Extensions.DependencyInjection;
using PlatfozaTestTask.API.Mapping;
using PlatfozaTestTask.API.Models;
using PlatfozaTestTask.API.Providers;
using PlatfozaTestTask.API.Repositorues;
using PlatfozaTestTask.API.Resolvers;
using PlatfozaTestTask.API.Services;

namespace PlatfozaTestTask.API.Helpers
{
    public static class DiHelper
    {
        public static void AddSingleton(this IServiceCollection services)
        {
            services.AddSingleton<NHibernateHelper>();
            services.AddSingleton<SessionProvider>();
            services.AddSingleton<AutomapperConfigurationStorage>();
            services.AddSingleton<DbInitializer>();
        }

        public static void AddHelpers(this IServiceCollection services)
        {
            services.AddTransient<IAutomapperHelper, AutomapperHelper>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Account>, EntityRepository<Account>>();
            services.AddTransient<IRepository<User>, EntityRepository<User>>();
        }

        public static void AddResolvers(this IServiceCollection services)
        {
            services.AddTransient<UserResolver>();
        }
    }
}