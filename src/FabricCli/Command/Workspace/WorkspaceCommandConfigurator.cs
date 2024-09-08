using Spectre.Console.Cli;

namespace FabricCli.Command.Workspace
{
    public class WorkspaceCommandConfigurator : ICommandConfigurator
    {
        public void Configure(IConfigurator config)
        {
            config.AddBranch("workspace", workspace =>
            {
                workspace.SetDescription("Commands for managing workspaces.");

                
                workspace.AddCommand<List>("list")
                         .WithAlias("-l")
                         .WithDescription("List all available workspaces.");

                workspace.AddCommand<Create>("create")
                         .WithAlias("-c")
                         .WithDescription("Creates a new workspace.")
                         .WithExample(["workspace", "create", "new workspace"]);
            });
        }
    }
}
