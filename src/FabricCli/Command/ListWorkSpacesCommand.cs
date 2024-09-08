using FabricCli.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Spectre.Console.Cli;
using Spectre.Console;

namespace FabricCli.Command
{
    public class ListWorkspacesCommand : Command<ListWorkspacesCommand.Settings>
    {
        private readonly IFabricService _fabricService;

        public ListWorkspacesCommand(IFabricService fabricService)
        {
            _fabricService = fabricService;
        }

        public class Settings : CommandSettings
        {
            [CommandOption("-l|--list")]
            [Description("List all available workspaces.")]
            public bool List { get; set; }
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            var workspaces = _fabricService.GetWorkspaces();

            AnsiConsole.MarkupLine($"[bold yellow]Number of workspaces:[/] {workspaces.Count()}");
            foreach (var workspace in workspaces)
            {
                AnsiConsole.MarkupLine($"[green]Workspace:[/] {workspace.DisplayName}, [blue]Capacity ID:[/] {workspace.CapacityId}");
            }

            return 0;  // Exit code 0 means success
        }
        
    }
}
