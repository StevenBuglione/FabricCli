using Azure;

using Microsoft.Fabric.Api.Core.Models;
using Microsoft.Fabric.Api.Utils;

namespace FabricCli.Service
{
    public interface IFabricService
    {
        PageableResponse<Workspace> GetWorkspaces();
        Response<Workspace> CreateWorkspace(string name);
    }
}
