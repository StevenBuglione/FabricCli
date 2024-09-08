using FabricCli.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;


namespace FabricCli.Factory
{
    public static class CommandAppFactory
    {
        public static CommandApp Create()
        {
            var registrations = ServiceProviderConfig.Configure();
            var serviceProvider = registrations.BuildServiceProvider();
            var registrar = new Infrastructure.TypeRegistrar(registrations);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.SetApplicationName("fabric")
                      .SetApplicationVersion("1.0.0");

                var configurators = serviceProvider.GetServices<Command.ICommandConfigurator>();
                foreach (var configurator in configurators)
                {
                    configurator.Configure(config);
                }
            });


            return app;
        }
    }
}
