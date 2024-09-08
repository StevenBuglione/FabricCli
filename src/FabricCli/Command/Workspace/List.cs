using FabricCli.Service;
using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;



namespace FabricCli.Command.Workspace
{
    public class List : Command<List.Settings>
    {
        private readonly IFabricService _fabricService;

        public List(IFabricService fabricService)
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
                AnsiConsole.MarkupLine($"[green]Workspace:[/] {workspace.DisplayName}, [blue]Workspace ID:[/] {workspace.Id}");
            }

            return 0;  
        }
    }
}