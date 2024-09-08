using FabricCli.Service;
using Spectre.Console.Cli;
using Spectre.Console;

using System.ComponentModel;
using Azure;


namespace FabricCli.Command.Workspace
{
    public class Create : Command<Create.Settings>
    {
        private readonly IFabricService _fabricService;

        public Create(IFabricService fabricService)
        {
            _fabricService = fabricService;
        }

        public class Settings : CommandSettings
        {
            [CommandArgument(0, "<NAME>")]
            [Description("The name of the workspace to create.")]
            public string? WorkspaceName { get; set; }
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            if (string.IsNullOrEmpty(settings.WorkspaceName))
            {
                AnsiConsole.MarkupLine("[red]Error:[/] Workspace name must be provided.");
                return 1;  
            }

            try
            {
                var response = _fabricService.CreateWorkspace(settings.WorkspaceName);
                AnsiConsole.MarkupLine($"[green]Workspace '{settings.WorkspaceName}' created successfully.[/]");
                AnsiConsole.MarkupLine($"'{response.Value.Id}'");
                return 0;  
               
            }
            catch (RequestFailedException ex)
            {
                AnsiConsole.MarkupLine($"[red]Error: '{ex.Message}' ErrorCode: '{ex.ErrorCode}'");
                return 1;  
            }
        }
    }
}
