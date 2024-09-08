using FabricCli.Model;
using Microsoft.Fabric.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricCli.Service
{
    public class FabricService : IFabricService
    {
        private readonly FabricClient _fabricClient;

        public FabricService(FabricClient fabricClient)
        {
            _fabricClient = fabricClient;
        }

        public IEnumerable<FabricWorkspace> GetWorkspaces()
        {
            // Use the FabricClient to fetch items and map them to FabricItem
            return _fabricClient.Core.Workspaces.ListWorkspaces()
                .Select(workspace => new FabricWorkspace
                {
                    DisplayName = workspace.DisplayName,
                    CapacityId = workspace.CapacityId
                })
                .ToList();
        }
    }
}
