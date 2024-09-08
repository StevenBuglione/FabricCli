using FabricCli.Command;
using FabricCli.Factories;
using FabricCli.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Fabric.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICommand = FabricCli.Command.ICommand;

namespace FabricCli.Configuration
{
    public class ServiceProviderConfig
    {
        public static ServiceProvider Configure()
        {
            // Create an instance of FabricClientFactory
            var fabricClientFactory = new FabricClientFactory();
            var fabricClient = fabricClientFactory.CreateFabricClient();

            return new ServiceCollection()
                .AddSingleton(fabricClient) // Register FabricClient as a singleton
                .AddSingleton<FabricClientFactory>() // Register FabricClientFactory as a singleton
                .AddSingleton<IFabricService, FabricService>() // Register IFabricService as a singleton
                .AddSingleton<ICommand, ListWorkspacesCommand>()
                .BuildServiceProvider();
        }
    }
}
