using FabricCli.Command;
using FabricCli.Factory;
using FabricCli.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FabricCli.Configuration
{
    public class ServiceProviderConfig
    {
        public static IServiceCollection Configure()
        {
            var services = new ServiceCollection();

            
            services.AddSingleton<FabricClientFactory>();
            services.AddSingleton(provider =>
            {
                var factory = provider.GetRequiredService<FabricClientFactory>();
                return factory.CreateFabricClient();
            });
            services.AddSingleton<IFabricService, FabricService>();

            
            RegisterCommandConfigurators(services);

            return services;
        }

        private static void RegisterCommandConfigurators(IServiceCollection services)
        {
            var commandConfiguratorType = typeof(ICommandConfigurator);
            var implementations = Assembly.GetExecutingAssembly()
                                          .GetTypes()
                                          .Where(t => commandConfiguratorType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

            foreach (var implementation in implementations)
            {
                services.AddSingleton(commandConfiguratorType, implementation);
            }
        }
    }
}