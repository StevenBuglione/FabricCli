using FabricCli.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricCli.Command
{
    public class ListWorkspacesCommand : ICommand
    {
        private readonly IFabricService _fabricService;

        public ListWorkspacesCommand(IFabricService fabricService)
        {
            _fabricService = fabricService;
        }

        public void Execute()
        {
            var workspaces = _fabricService.GetWorkspaces();
            Console.WriteLine("Number of workspaces: " + workspaces.Count());
            foreach (var workspace in workspaces)
            {
                Console.WriteLine($"Workspace: {workspace.DisplayName}, Capacity ID: {workspace.CapacityId}");
            }
        }
    }
}
