using FabricCli.Command;
using FabricCli.Factories;
using FabricCli.Service;
using Microsoft.Extensions.DependencyInjection;


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

            return services;
        }
    }
}
