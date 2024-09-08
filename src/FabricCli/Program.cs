using FabricCli.Command;
using FabricCli.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FabricCli
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Set up the DI container using the configuration
            var serviceProvider = ServiceProviderConfig.Configure();

            // Parse command-line arguments
            if (args.Length == 2 && (args[0] == "workspace" && (args[1] == "list" || args[1] == "-l")))
            {
                // Resolve the command and execute it
                var command = serviceProvider.GetService<ICommand>();
                command.Execute();
            }
            else
            {
                Console.WriteLine("Invalid command. Usage: fabric workspace list or fabric workspace -l");
            }
        }
    }
}
