using Azure.Core;
using Azure.Identity;
using Microsoft.Fabric.Api;

namespace FabricCli
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an EnvironmentCredential instance
            TokenCredential credential = new EnvironmentCredential();

            string[] scopes = new[] { "https://api.fabric.microsoft.com/.default" };


            // Create a TokenRequestContext with the specified scopes
            TokenRequestContext context = new TokenRequestContext(scopes);

            // Get the access token
            AccessToken accessToken = credential.GetToken(context, CancellationToken.None);

            // Create a new instance of the FabricClient
            FabricClient fabricClient = new FabricClient(accessToken.Token);

            // Get the list of workspaces using the client
            var workspaces = fabricClient.Core.Workspaces.ListWorkspaces().ToList();
            Console.WriteLine("Number of workspaces: " + workspaces.Count);
            foreach (var workspace in workspaces)
            {
                Console.WriteLine($"Workspace: {workspace.DisplayName}, Capacity ID: {workspace.CapacityId}");
            }
        }
    }
}
