using Spectre.Console.Cli;

namespace FabricCli.Command
{
    public interface ICommandConfigurator
    {
        void Configure(IConfigurator config);
    }
}
