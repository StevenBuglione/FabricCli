using Azure.Core;
using Azure.Identity;
using Microsoft.Fabric.Api;


namespace FabricCli.Factory
{
    public class FabricClientFactory
    {
        public FabricClientFactory() { }

        public FabricClient CreateFabricClient()
        {
            
            TokenCredential credential = new EnvironmentCredential();

            string[] scopes = ["https://api.fabric.microsoft.com/.default"];

            
            TokenRequestContext context = new TokenRequestContext(scopes);

            AccessToken accessToken = credential.GetToken(context, CancellationToken.None);

            return new FabricClient(accessToken.Token);
        }

    }
}
