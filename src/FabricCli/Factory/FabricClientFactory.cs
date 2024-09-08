using Azure.Core;
using Azure.Identity;
using Microsoft.Fabric.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricCli.Factories
{
    public class FabricClientFactory
    {
        public FabricClientFactory() { }

        public FabricClient CreateFabricClient()
        {
            // Create an EnvironmentCredential instance
            TokenCredential credential = new EnvironmentCredential();

            string[] scopes = ["https://api.fabric.microsoft.com/.default"];

            // Create a TokenRequestContext with the specified scopes
            TokenRequestContext context = new TokenRequestContext(scopes);

            // Get the access token
            AccessToken accessToken = credential.GetToken(context, CancellationToken.None);

            // Create a new instance of the FabricClient
            return new FabricClient(accessToken.Token);
        }

    }
}
