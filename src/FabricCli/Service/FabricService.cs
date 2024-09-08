using Azure;
using Microsoft.Fabric.Api;
using Microsoft.Fabric.Api.Core.Models;
using Microsoft.Fabric.Api.Utils;

namespace FabricCli.Service
{
    public class FabricService : IFabricService
    {
        private readonly FabricClient _fabricClient;

        public FabricService(FabricClient fabricClient)
        {
            _fabricClient = fabricClient;
        }

        public Response<Workspace> CreateWorkspace(string name)
        {
            CreateWorkspaceRequest request = new CreateWorkspaceRequest(name);
            Response<Workspace> response = _fabricClient.Core.Workspaces.CreateWorkspace(request);
            return response;
        }

        public PageableResponse<Workspace> GetWorkspaces()
        {
            var response = _fabricClient.Core.Workspaces.ListWorkspaces();
            return response;
        }
        
    }
}
