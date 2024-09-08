using FabricCli.Command;
using FabricCli.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;


namespace FabricCli
{
    public class Program
    {
        static int Main(string[] args)
        {
            // Configure services
            var registrations = ServiceProviderConfig.Configure();
            var registrar = new TypeRegistrar(registrations);

            // Create CommandApp with DI TypeRegistrar
            var app = new CommandApp(registrar);

            // Register the parent 'workspace' command and the 'list' subcommand
            app.Configure(config =>
            {
                config.SetApplicationName("fabric")
                .SetApplicationVersion("1.0.0");

                config.AddBranch("workspace", workspace =>
                {
                    workspace.SetDescription("Commands for managing workspaces.");

                    // Register the 'list' subcommand under 'workspace'
                    workspace.AddCommand<ListWorkspacesCommand>("list")
                        .WithAlias("-l")
                        .WithDescription("List all available workspaces.");
                });
            });

            return app.Run(args);
        }
    }
}
